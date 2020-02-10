
/*************** GESTION DES WORKFLOW **********************/

CREATE TABLE WorkflowState (
	id BIGINT IDENTITY(1,1) NOT NULL,
	stateName VARCHAR(255) NOT NULL,
	stateShortName VARCHAR(10) NOT NULL,
	stateDescription VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	active INT NOT NULL,
	CONSTRAINT PK_WorkflowState PRIMARY KEY CLUSTERED (id)
)

CREATE TABLE Transition(
	id BIGINT IDENTITY(1,1) NOT NULL,
	transitionName VARCHAR(255) NOT NULL,
	internalName VARCHAR(255) NOT NULL, /* Unique */
	transitionShortName VARCHAR(10) NOT NULL,
	description VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	active INT NOT NULL,
	endStateId BIGINT NOT NULL,
	actions VARCHAR(4000) NULL,
	behavior INT, /*par exemple nécessite une validation du formulaire, necessite un commentaire */
	affichagePriority INT,
	CONSTRAINT PK_Transition PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE Transition WITH CHECK ADD CONSTRAINT fk_Transition_endStateId FOREIGN KEY(endStateId)
REFERENCES WorkflowState (id)


CREATE TABLE TransitionStartState(
	id BIGINT IDENTITY(1,1) NOT NULL,
	transitionId BIGINT NOT NULL,
	startStateId BIGINT NOT NULL,
	CONSTRAINT PK_TransitionStartState PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE TransitionStartState  WITH CHECK ADD  CONSTRAINT fk_TransitionStartState_startStateId FOREIGN KEY(startStateId)
REFERENCES WorkflowState (id)

ALTER TABLE TransitionStartState  WITH CHECK ADD  CONSTRAINT fk_TransitionStartState_transitionId FOREIGN KEY(transitionId)
REFERENCES Transition (id)



/*@@TODO ajouter TransitionParamètre + TransitionPrerequis*/

CREATE TABLE WorkFlow (
	id BIGINT IDENTITY(1,1) NOT NULL,
	workflowName VARCHAR(255) NOT NULL,
	workflowShortName VARCHAR(10) NOT NULL,
	workflowDescription VARCHAR(4000) NULL,
	startStateId BIGINT NOT NULL,
	CONSTRAINT PK_WorkFlow PRIMARY KEY CLUSTERED (ID)
)
ALTER TABLE WorkFlow  WITH CHECK ADD  CONSTRAINT fk_WorkFlow_startStateId FOREIGN KEY(startStateId)
REFERENCES WorkflowState (id)



CREATE TABLE WorkFlow_Transition (
	id BIGINT IDENTITY(1,1) NOT NULL,
	workflowId BIGINT NOT NULL,
	transitionId BIGINT NOT NULL,
	active INT NOT NULL,
	CONSTRAINT PK_WorkFlow_Transition PRIMARY KEY CLUSTERED (ID)
)
ALTER TABLE WorkFlow_Transition  WITH CHECK ADD  CONSTRAINT fk_WorkFlow_Transition_transitionId FOREIGN KEY(TransitionId)
REFERENCES Transition (id)

ALTER TABLE WorkFlow_Transition  WITH CHECK ADD  CONSTRAINT fk_WorkFlow_Transition_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)



/****** Gestion des demandes *********************************/


CREATE TABLE DemandType (
	id BIGINT IDENTITY(1,1) NOT NULL,
	typeName VARCHAR(255) NOT NULL,
	typeInternalName VARCHAR(255) NOT NULL, /* Unique */
	typeShortName VARCHAR(10) NOT NULL,
	typeDescription VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	active INT NOT NULL,
	workflowId BIGINT NOT NULL,/* @@TODO CHANGER le nom*/
	CONSTRAINT PK_DemandType PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE DemandType  WITH CHECK ADD  CONSTRAINT fk_DemandType_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)


CREATE TABLE DemandDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	dynPropName VARCHAR(255) NOT NULL,
	dynPropType VARCHAR(255) NOT NULL, /* string, date, entier, float, decimal, list, coordonnées spatiale */ -- anciennement nature 
	active INT NOT NULL,
	CONSTRAINT PK_DemandDynProp PRIMARY KEY CLUSTERED (id)
)


CREATE TABLE DemandType_DemandDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	dynPropId BIGINT NOT NULL,
	typeId BIGINT NOT NULL,
	active INT NOT NULL,
	CONSTRAINT PK_DemandType_DemandDynProp PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE DemandType_DemandDynProp  WITH CHECK ADD  CONSTRAINT fk_DemandType_DemandDynProp_dynPropId FOREIGN KEY(dynPropId)
REFERENCES DemandDynProp (id)

ALTER TABLE DemandType_DemandDynProp  WITH CHECK ADD  CONSTRAINT fk_DemandType_DemandDynProp_typeId FOREIGN KEY(typeId)
REFERENCES DemandType (id)



CREATE TABLE Demand (
	id BIGINT IDENTITY(1,1) NOT NULL,
	workFlowId BIGINT NOT NULL,
	typeId BIGINT NOT NULL,
	workflowStateId BIGINT NOT NULL,
	author VARCHAR(200) NOT NULL,
	createDate DATETIME NOT NULL,
	CONSTRAINT PK_Demand PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE Demand  WITH CHECK ADD  CONSTRAINT fk_Demand_demandTypeId FOREIGN KEY(typeId)
REFERENCES DemandType (id)

ALTER TABLE Demand WITH CHECK ADD  CONSTRAINT fk_Demand_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)

ALTER TABLE Demand WITH CHECK ADD  CONSTRAINT fk_Demand_workflowStateId FOREIGN KEY(workflowStateId)
REFERENCES WorkflowState (id)



CREATE TABLE DemandDynPropValue (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandId BIGINT NOT NULL,
	dynPropId BIGINT NOT NULL,
	changeDate DATETIME NOT NULL,
	valueString VARCHAR(MAX) NULL,
	valueInt BIGINT NULL,
	valueDate DATETIME NULL,
	valueReal FLOAT NULL,
	valueDecimal DECIMAL(30,10) NULL,
	valueGeom geometry NULL,
	CONSTRAINT PK_ValueDemandDynProp PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE DemandDynPropValue WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValue_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE DemandDynPropValue  WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValue_dynPropId FOREIGN KEY(dynPropId)
REFERENCES DemandDynProp (id)



CREATE TABLE DemandDynPropValueHisto (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandId BIGINT NOT NULL,
	dynPropId BIGINT NOT NULL,
	changeDate DATETIME NOT NULL,
	valueString VARCHAR(MAX) NULL,
	valueInt BIGINT NULL,
	valueDate 	DATETIME NULL,
	valueReal  FLOAT NULL,
	valueDecimal DECIMAL(30,10) NULL,
	valueGeom geometry NULL,
	CONSTRAINT PK_ValueDemandDynPropHisto PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE DemandDynPropValueHisto  WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValueHisto_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE DemandDynPropValueHisto  WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValueHisto_dynPropId FOREIGN KEY(dynPropId)
REFERENCES DemandDynProp (id)



CREATE TABLE DemandTransitionHisto (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandId BIGINT NOT NULL,
	transitionId BIGINT NOT NULL,
	transitionDate DATETIME NOT NULL,
	Comment VARCHAR(MAX) NULL,
	CONSTRAINT PK_DemandTransitionHisto PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE DemandTransitionHisto  WITH CHECK ADD  CONSTRAINT fk_DemandTransitionHisto_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE DemandTransitionHisto  WITH CHECK ADD  CONSTRAINT fkDemandTransitionHisto_transitionId FOREIGN KEY(transitionId)
REFERENCES Transition (id)




/****** Gestion des Tickets *********************************/


CREATE TABLE TicketType (
	id BIGINT IDENTITY(1,1) NOT NULL,
	typeName VARCHAR(255) NOT NULL,
	typeInternalName VARCHAR(255) NOT NULL, /* Unique */
	typeShortName VARCHAR(10) NOT NULL,
	typeDescription VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	active INT NOT NULL,
	workflowId BIGINT not null

	CONSTRAINT PK_TicketType PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE TicketType  WITH CHECK ADD  CONSTRAINT fk_TicketType_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)


CREATE TABLE TicketDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	dynPropName VARCHAR(255) NOT NULL,
	dynPropType VARCHAR(255) NOT NULL, /* string, date, entier, float, decimal, list, coordonnées spatiale */ -- anciennement nature 
	active INT NOT NULL,
	CONSTRAINT PK_TicketDynProp PRIMARY KEY CLUSTERED (id)
)


CREATE TABLE TicketType_TicketDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	dynPropId BIGINT NOT NULL,
	typeId BIGINT NOT NULL,
	active INT NOT NULL,
	CONSTRAINT PK_TicketType_TicketDynProp PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE TicketType_TicketDynProp  WITH CHECK ADD  CONSTRAINT fk_TicketType_TicketDynProp_dynPropId FOREIGN KEY(dynPropId)
REFERENCES TicketDynProp (id)

ALTER TABLE TicketType_TicketDynProp  WITH CHECK ADD  CONSTRAINT fk_TicketType_TicketDynProp_typeId FOREIGN KEY(typeId)
REFERENCES TicketType (id)


CREATE TABLE Ticket (
	id BIGINT IDENTITY(1,1) NOT NULL,
	typeId BIGINT NOT NULL,
	ticketTitle VARCHAR(200) NOT NULL,
	ticketContent VARCHAR(MAX) NOT NULL,
	ticketStatus BIGINT NOT NULL,
	author VARCHAR(200) NOT NULL,
	createDate DATETIME NOT NULL,
	closeDate DATETIME NULL,
	criticality INT NOT NULL,
	project VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Ticket PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE Ticket  WITH CHECK ADD  CONSTRAINT fk_Ticket_TicketTypeId FOREIGN KEY(typeId)
REFERENCES TicketType (id)


CREATE TABLE TicketDynPropValue (
	id BIGINT IDENTITY(1,1) NOT NULL,
	ticketId BIGINT NOT NULL,
	dynPropId BIGINT NOT NULL,
	changeDate DATETIME NOT NULL,
	valueString VARCHAR(MAX) NULL,
	valueInt BIGINT NULL,
	valueDate DATETIME NULL,
	valueReal FLOAT NULL,
	valueDecimal DECIMAL(30,10) NULL,
	valueGeom geometry NULL,
	CONSTRAINT PK_ValueTicketDynProp PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE TicketDynPropValue WITH CHECK ADD  CONSTRAINT fk_TicketDynPropValue_TicketId FOREIGN KEY(TicketId)
REFERENCES Ticket (id)

ALTER TABLE TicketDynPropValue  WITH CHECK ADD  CONSTRAINT fk_TicketDynPropValue_dynPropId FOREIGN KEY(dynPropId)
REFERENCES TicketDynProp (id)



CREATE TABLE TicketDynPropValueHisto (
	id BIGINT IDENTITY(1,1) NOT NULL,
	ticketId BIGINT NOT NULL,
	dynPropId BIGINT NOT NULL,
	changeDate DATETIME NOT NULL,
	valueString VARCHAR(MAX) NULL,
	valueInt BIGINT NULL,
	valueDate DATETIME NULL,
	valueReal FLOAT NULL,
	valueDecimal DECIMAL(30,10) NULL,
	valueGeom geometry NULL,
	CONSTRAINT PK_ValueTicketDynPropHisto PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE TicketDynPropValueHisto  WITH CHECK ADD  CONSTRAINT fk_TicketDynPropValueHisto_TicketId FOREIGN KEY(TicketId)
REFERENCES Ticket (id)

ALTER TABLE TicketDynPropValueHisto  WITH CHECK ADD  CONSTRAINT fk_TicketDynPropValueHisto_dynPropId FOREIGN KEY(dynPropId)
REFERENCES TicketDynProp (id)

/****** Gestion des formulaires *********************************/

CREATE TABLE TicketTransitionHisto (
	id BIGINT IDENTITY(1,1) NOT NULL,
	ticketId BIGINT NOT NULL,
	transitionId BIGINT NOT NULL,
	transitionDate DATETIME NOT NULL,
	Comment VARCHAR(MAX) NULL,
	CONSTRAINT PK_TicketTransitionHisto PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE TicketTransitionHisto  WITH CHECK ADD CONSTRAINT fk_TicketTransitionHisto_TicketId FOREIGN KEY(TicketId)
REFERENCES Ticket (id)

ALTER TABLE TicketTransitionHisto  WITH CHECK ADD CONSTRAINT fkTicketTransitionHisto_transitionId FOREIGN KEY(transitionId)
REFERENCES Transition (id)

create table TicketFormConfig (
	id BIGINT IDENTITY(1,1) NOT NULL,
	ticketTypeId BIGINT NOT NULL,
	title VARCHAR(100) NOT NULL,
	columnNumber INT NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	validationMessage VARCHAR(100), -- A RAJOUTER -- message apparaissant à la validation du formulaire (facultatif)
	cssClass VARCHAR(MAX),
	behavior INT NOT NULL, --configurationLabel
	CONSTRAINT PK_FormConfig PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE TicketFormConfig  WITH CHECK ADD  CONSTRAINT fk_TicketFormConfig_ticketTypeId FOREIGN KEY(ticketTypeId)
REFERENCES TicketType (id)

create table TicketFormGroup (
	id BIGINT IDENTITY(1,1) NOT NULL,	
	formConfigId BIGINT NOT NULL,
	title VARCHAR(100) NOT NULL,
	columnIndex INT NOT NULL,
	groupOrder INT NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	cssClass VARCHAR(MAX),
	behavior INT NOT NULL, -- Label visible, bloc titre visible,type de groupe...
	CONSTRAINT PK_FormGroup PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE TicketFormGroup  WITH CHECK ADD  CONSTRAINT fk_TicketFormGroup_formConfigId FOREIGN KEY(formConfigId)
REFERENCES TicketFormConfig (id)


create table TicketFormField (
	id BIGINT IDENTITY(1,1) NOT NULL,
	formGroupId BIGINT NOT NULL,
	fieldName VARCHAR(50) NOT NULL,
	fieldType VARCHAR(50) NOT NULL,
	fieldLabel VARCHAR(50) NOT NULL,
	isDynamic BIT NOT NULL,
	fieldParameters VARCHAR(MAX) NOT NULL, --(min, max, size, placeholder, disabled, ...)
	fieldOrder INT NOT NULL,
	tooltip VARCHAR(50) NULL, --équivalent title html
	defaultValue VARCHAR(50) NULL,
	active BIT NOT NULL, -- actif/inactif
	workflowStateId BIGINT NULL,
	cssClass VARCHAR(MAX),
	behavior INT NOT NULL, -- Label visible, ...
	CONSTRAINT PK_FormField PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE TicketFormField  WITH CHECK ADD  CONSTRAINT fk_TicketFormField_formGroupId FOREIGN KEY(formGroupId)
REFERENCES TicketFormGroup (id)

ALTER TABLE TicketFormField  WITH CHECK ADD  CONSTRAINT fk_TicketFormField_workflowStateId FOREIGN KEY(workflowStateId)
REFERENCES WorkflowState (id)



/****** Tables communes *********************************/

CREATE TABLE Modalist (
	id BIGINT IDENTITY(1,1) NOT NULL,
	modalistGroup VARCHAR(50) NOT NULL,
	modalistRang INT NOT NULL,
	modalistLabel VARCHAR(200) NOT NULL,
	modalistAbrev VARCHAR(50) NOT NULL,
	modalistOrdreAffichage INT NULL,
	createDate DATETIME NOT NULL,
	CONSTRAINT PK_Modalist PRIMARY KEY CLUSTERED (ID)
)