
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
	demandTypeName VARCHAR(255) NOT NULL,
	demandTypeInternalName VARCHAR(255) NOT NULL, /* Unique */
	demandTypeShortName VARCHAR(10) NOT NULL,
	demandTypeDescription VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	active INT NOT NULL,
	workflowId BIGINT NOT NULL,/* @@TODO CHANGER le nom*/
	CONSTRAINT PK_DemandType PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE DemandType  WITH CHECK ADD  CONSTRAINT fk_DemandType_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)


CREATE TABLE DemandDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandDynPropName VARCHAR(255) NOT NULL,
	DynPropType VARCHAR(255) NOT NULL, /* string, date, entier, float, decimal, list, coordonnées spatiale */ -- anciennement nature 
	active INT NOT NULL,
	CONSTRAINT PK_DemandDynProp PRIMARY KEY CLUSTERED (id)
)


CREATE TABLE DemandType_DemandDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandDynPropId BIGINT NOT NULL,
	demandTypeId BIGINT NOT NULL,
	active INT NOT NULL,
	CONSTRAINT PK_DemandType_DemandDynProp PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE DemandType_DemandDynProp  WITH CHECK ADD  CONSTRAINT fk_DemandType_DemandDynProp_demandDynPropId FOREIGN KEY(demandDynPropId)
REFERENCES DemandDynProp (id)

ALTER TABLE DemandType_DemandDynProp  WITH CHECK ADD  CONSTRAINT fk_DemandType_DemandDynProp_demandTypeId FOREIGN KEY(demandTypeId)
REFERENCES DemandType (id)



CREATE TABLE Demand (
	id BIGINT IDENTITY(1,1) NOT NULL,
	workFlowId BIGINT NOT NULL,
	demandTypeid BIGINT NOT NULL,
	workflowStateId BIGINT NOT NULL,
	author VARCHAR(200) NOT NULL,
	createDate DATETIME NOT NULL,
	CONSTRAINT PK_Demand PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE Demand  WITH CHECK ADD  CONSTRAINT fk_Demand_demandTypeId FOREIGN KEY(demandTypeId)
REFERENCES DemandType (id)

ALTER TABLE Demand WITH CHECK ADD  CONSTRAINT fk_Demand_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)

ALTER TABLE Demand WITH CHECK ADD  CONSTRAINT fk_Demand_workflowStateId FOREIGN KEY(workflowStateId)
REFERENCES WorkflowState (id)



CREATE TABLE DemandDynPropValue (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandId BIGINT NOT NULL,
	demandDynPropId BIGINT NOT NULL,
	changeDate DATETIME,
	stringValue VARCHAR(MAX) NULL,
	intValue BIGINT NULL,
	dateValue 	DATETIME NULL,
	realValue  FLOAT NULL,
	decimalValue DECIMAL(30,10) NULL,
	geomValue geometry NULL
	CONSTRAINT PK_ValueDemandDynProp PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE DemandDynPropValue WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValue_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE DemandDynPropValue  WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValue_demandDynPropId FOREIGN KEY(demandDynPropId)
REFERENCES DemandDynProp (id)



CREATE TABLE DemandDynPropValueHisto (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandId BIGINT NOT NULL,
	demandDynPropId BIGINT NOT NULL,
	changeDate DATETIME,
	stringValue VARCHAR(MAX) NULL,
	intValue BIGINT NULL,
	dateValue 	DATETIME NULL,
	realValue  FLOAT NULL,
	decimalValue DECIMAL(30,10) NULL,
	geomValue geometry NULL,
	CONSTRAINT PK_ValueDemandDynPropHisto PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE DemandDynPropValueHisto  WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValueHisto_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE DemandDynPropValueHisto  WITH CHECK ADD  CONSTRAINT fk_DemandDynPropValueHisto_demandDynPropId FOREIGN KEY(demandDynPropId)
REFERENCES DemandDynProp (id)

create table FormConfig (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandTypeId BIGINT NOT NULL,
	title VARCHAR(100) NOT NULL,
	columnNumber INT NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	validationMessage VARCHAR(100), -- A RAJOUTER -- message apparaissant à la validation du formulaire (facultatif)
	cssClass VARCHAR(MAX),
	behavior INT NOT NULL, --configurationLabel
	CONSTRAINT PK_FormConfig PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE FormConfig  WITH CHECK ADD  CONSTRAINT fk_FormConfig_demandTypeId FOREIGN KEY(demandTypeId)
REFERENCES DemandType (id)

create table FormGroup (
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

ALTER TABLE FormGroup  WITH CHECK ADD  CONSTRAINT fk_FormGroup_formConfigId FOREIGN KEY(formConfigId)
REFERENCES FormConfig (id)


create table FormField (
	id BIGINT IDENTITY(1,1) NOT NULL,
	formGroupId BIGINT NOT NULL,
	fieldName VARCHAR(50) NOT NULL,
	fieldType VARCHAR(50) NOT NULL,
	fieldLabel VARCHAR(50) NOT NULL,
	isDynamic BIT NOT NULL,
	fieldParameters VARCHAR(MAX) NOT NULL, --(min, max, size, placeholder, disabled, ...)
	fieldOrder INT NOT NULL,
	tooltip VARCHAR(50) NOT NULL, --équivalent title html
	defaultValue VARCHAR(50) NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	workflowStateId BIGINT NULL,
	cssClass VARCHAR(MAX),
	behavior INT NOT NULL, -- Label visible, ...
	CONSTRAINT PK_FormField PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE FormField  WITH CHECK ADD  CONSTRAINT fk_FormField_formGroupId FOREIGN KEY(formGroupId)
REFERENCES FormGroup (id)

ALTER TABLE FormField  WITH CHECK ADD  CONSTRAINT fk_FormField_workflowStateId FOREIGN KEY(workflowStateId)
REFERENCES WorkflowState (id)
