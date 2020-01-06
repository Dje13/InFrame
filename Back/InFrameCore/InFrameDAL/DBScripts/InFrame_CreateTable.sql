
/*************** GESTION DES WORKFLOW **********************/

CREATE TABLE WorkflowState (
	id BIGINT IDENTITY(1,1) NOT NULL,
	stateName VARCHAR(255) NOT NULL,
	stateShortName VARCHAR(10) NOT NULL,
	stateDescription VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	workflowState INT NOT NULL,
	CONSTRAINT PK_WorkflowState PRIMARY KEY CLUSTERED (id)
)

CREATE TABLE Transition(
	id BIGINT IDENTITY(1,1) NOT NULL,
	transitionName VARCHAR(255) NOT NULL,
	internalName VARCHAR(255) NOT NULL, /* Unique */
	transitionShortName VARCHAR(10) NOT NULL,
	description VARCHAR(4000) NULL,
	icon VARCHAR(400) NULL,
	workflowState INT NOT NULL,
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
	workflowState INT NOT NULL,
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
	workflowState INT NOT NULL,
	workflowId BIGINT NOT NULL,/* @@TODO CHANGER le nom*/
	CONSTRAINT PK_DemandType PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE DemandType  WITH CHECK ADD  CONSTRAINT fk_DemandType_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)


CREATE TABLE DemandDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandDynPropName VARCHAR(255) NOT NULL,
	demandType VARCHAR(255) NOT NULL, /* string, date, entier, float, decimal, list, coordonnées spatiale */ -- anciennement nature 
	workflowState INT NOT NULL,
	CONSTRAINT PK_DemandDynProp PRIMARY KEY CLUSTERED (id)
)


CREATE TABLE DemandType_DemandDynProp (
	id BIGINT IDENTITY(1,1) NOT NULL,
	demandDynPropId BIGINT NOT NULL,
	demandTypeId BIGINT NOT NULL,
	workflowState INT NOT NULL,
	CONSTRAINT PK_DemandType_DemandDynProp PRIMARY KEY CLUSTERED (id)
)

ALTER TABLE DemandType_DemandDynProp  WITH CHECK ADD  CONSTRAINT fk_DemandType_DemandDynProp_demandDynPropId FOREIGN KEY(demandDynPropId)
REFERENCES DemandDynProp (id)

ALTER TABLE DemandType_DemandDynProp  WITH CHECK ADD  CONSTRAINT fk_DemandType_DemandDynProp_demandTypeId FOREIGN KEY(demandTypeId)
REFERENCES DemandType (id)



CREATE TABLE Demand (
	id BIGINT IDENTITY(1,1) NOT NULL,
	etatId BIGINT NOT NULL,
	workFlowId BIGINT NOT NULL,
	demandTypeid BIGINT NOT NULL,
	author VARCHAR(200) NOT NULL,
	createDate DATETIME NOT NULL,
	CONSTRAINT PK_Demand PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE Demand  WITH CHECK ADD  CONSTRAINT fk_Demand_demandTypeId FOREIGN KEY(demandTypeId)
REFERENCES DemandType (id)

ALTER TABLE Demand WITH CHECK ADD  CONSTRAINT fk_Demand_workflowId FOREIGN KEY(workflowId)
REFERENCES Workflow (id)


CREATE TABLE ValueDemandDynProp (
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

ALTER TABLE ValueDemandDynProp WITH CHECK ADD  CONSTRAINT fk_ValueDemandDynProp_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE ValueDemandDynProp  WITH CHECK ADD  CONSTRAINT fk_ValueDemandDynProp_demandDynPropId FOREIGN KEY(demandDynPropId)
REFERENCES DemandDynProp (id)



CREATE TABLE ValueDemandDynPropHisto (
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
	CONSTRAINT PK_ValueDemandDynPropHisto PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE ValueDemandDynPropHisto  WITH CHECK ADD  CONSTRAINT fk_ValueDemandDynPropHisto_demandId FOREIGN KEY(demandId)
REFERENCES Demand (id)

ALTER TABLE ValueDemandDynPropHisto  WITH CHECK ADD  CONSTRAINT fk_ValueDemandDynPropHisto_demandDynPropId FOREIGN KEY(demandDynPropId)
REFERENCES DemandDynProp (id)






