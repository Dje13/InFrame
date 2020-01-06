
/*************** GESTION DES WORKFLOW **********************/
CREATE TABLE Etat (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](255) NOT NULL,
	[nomcourt] [varchar](10) NOT NULL,
	[descr] [varchar](4000) NULL,
	[icon] [varchar](400) NULL,
	statut INT NOT NULL,
	CONSTRAINT [PK_Etat] PRIMARY KEY CLUSTERED (ID)
)

CREATE TABLE Transition(
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](255) NOT NULL,
	[nomInterne] [varchar](255) NOT NULL, /* Unique */
	[nomcourt] [varchar](10) NOT NULL,
	[descr] [varchar](4000) NULL,
	[icon] [varchar](400) NULL,
	statut INT NOT NULL,
	etatArriveeId BIGINT NOT NULL,
	actions [varchar](4000) NULL,
	comportement INT, /*par exemple nécessite une validation du formulaire, necessite un commentaire */
	prioriteAffichage INT,
	CONSTRAINT [PK_Transition] PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE Transition  WITH CHECK ADD  CONSTRAINT [fk_Transition_etatArriveeId] FOREIGN KEY([etatArriveeId])
REFERENCES [Etat] ([id])


CREATE TABLE TransitionEtatDepart(
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[transitionId] BIGINT NOT NULL,
	[etatDepartId] BIGINT NOT NULL,
	CONSTRAINT [PK_TransitionEtatDepart] PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE TransitionEtatDepart  WITH CHECK ADD  CONSTRAINT [fk_TransitionEtatDepart_etatDepartId] FOREIGN KEY([etatDepartId])
REFERENCES [Etat] ([id])

ALTER TABLE TransitionEtatDepart  WITH CHECK ADD  CONSTRAINT [fk_TransitionEtatDepart_transitionId] FOREIGN KEY([transitionId])
REFERENCES [Transition] ([id])



/*@@TODO ajouter TransitionParamètre + TransitionPrerequis*/

CREATE TABLE WorkFlow (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](255) NOT NULL,
	[nomcourt] [varchar](10) NOT NULL,
	[descr] [varchar](4000) NULL,
	etatDepartId BIGINT NOT NULL,
	CONSTRAINT [PK_WorkFlow] PRIMARY KEY CLUSTERED (ID)
)
ALTER TABLE WorkFlow  WITH CHECK ADD  CONSTRAINT [fk_WorkFlow_etatDepartId] FOREIGN KEY([etatDepartId])
REFERENCES [Etat] ([id])



CREATE TABLE WorkFlow_Transition (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[workflowId] [bigint] NOT NULL,
	[transitionId] [bigint] NOT NULL,
	statut INT NOT NULL,
	CONSTRAINT [PK_WorkFlow_Transition] PRIMARY KEY CLUSTERED (ID)
)
ALTER TABLE WorkFlow_Transition  WITH CHECK ADD  CONSTRAINT [fk_WorkFlow_Transition_transitionId] FOREIGN KEY([TransitionId])
REFERENCES [Transition] ([id])

ALTER TABLE WorkFlow_Transition  WITH CHECK ADD  CONSTRAINT [fk_WorkFlow_Transition_workflowId] FOREIGN KEY([workflowId])
REFERENCES [Workflow] ([id])



/****** Gestion des demandes *********************************/


CREATE TABLE DemandeType (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](255) NOT NULL,
	[nomInterne] [varchar](255) NOT NULL, /* Unique */
	[nomcourt] [varchar](10) NOT NULL,
	[descr] [varchar](4000) NULL,
	[icon] [varchar](400) NULL,
	statut INT NOT NULL,
	workFlowId BIGINT NOT NULL,/* @@TODO CHANGER le nom*/
	CONSTRAINT [PK_DemandeType] PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE DemandeType  WITH CHECK ADD  CONSTRAINT [fk_DemandeType_workflowId] FOREIGN KEY([workflowId])
REFERENCES [Workflow] ([id])


CREATE TABLE DemandeDynProp (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](255) NOT NULL,
	nature [varchar](255) NOT NULL, /* string, date, entier, float, decimal, list, coordonnées spatiale */
	statut INT NOT NULL,
	CONSTRAINT [PK_DemandeDynProp] PRIMARY KEY CLUSTERED (ID)
)


CREATE TABLE DemandeType_DemandeDynProp (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	demandeDynPropId [bigint] NOT NULL,
	demandeTypeId [bigint] NOT NULL,
	statut INT NOT NULL,
	CONSTRAINT [PK_DemandeType_DemandeDynProp] PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE DemandeType_DemandeDynProp  WITH CHECK ADD  CONSTRAINT [fk_DemandeType_DemandeDynProp_demandeDynPropId] FOREIGN KEY([demandeDynPropId])
REFERENCES [DemandeDynProp] ([id])

ALTER TABLE DemandeType_DemandeDynProp  WITH CHECK ADD  CONSTRAINT [fk_DemandeType_DemandeDynProp_demandeTypeId] FOREIGN KEY([demandeTypeId])
REFERENCES [DemandeType] ([id])



CREATE TABLE Demande (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	etatId bigint NOT NULL,
	workFlowId bigint NOT NULL,
	demandeTypeid bigint NOT NULL,
	demandeur VARCHAR(200) NOT NULL,
	dateCreation DATETIME NOT NULL,
	CONSTRAINT [PK_Demande] PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE Demande  WITH CHECK ADD  CONSTRAINT [fk_Demande_demandeTypeId] FOREIGN KEY([demandeTypeId])
REFERENCES [DemandeType] ([id])

ALTER TABLE Demande  WITH CHECK ADD  CONSTRAINT [fk_Demande_workflowId] FOREIGN KEY([workflowId])
REFERENCES [Workflow] ([id])


CREATE TABLE DemandeValeurDynProp (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	demandeId bigint NOT NULL,
	demandeDynPropId bigint NOT NULL,
	dateValeur DATETIME,
	valeurChaine VARCHAR(MAX) NULL,
	valeurEntier BIGINT NULL,
	valeurDate 	DATETIME NULL,
	valeurReel  FLOAT NULL,
	valeurDecimal DECIMAL(30,10) NULL,
	valeurSpatiale geometry NULL
	CONSTRAINT [PK_DemandeValeurDynProp] PRIMARY KEY CLUSTERED (ID)
)

ALTER TABLE DemandeValeurDynProp  WITH CHECK ADD  CONSTRAINT [fk_DemandeValeurDynProp_demandeId] FOREIGN KEY([demandeId])
REFERENCES [Demande] ([id])

ALTER TABLE DemandeValeurDynProp  WITH CHECK ADD  CONSTRAINT [fk_DemandeValeurDynProp_demandeDynPropId] FOREIGN KEY([demandeDynPropId])
REFERENCES [DemandeDynProp] ([id])



CREATE TABLE DemandeValeurDynPropHistorique (
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	demandeId bigint NOT NULL,
	demandeDynPropId bigint NOT NULL,
	dateValeur DATETIME,
	valeurChaine VARCHAR(MAX) NULL,
	valeurEntier BIGINT NULL,
	valeurDate 	DATETIME NULL,
	valeurReel  FLOAT NULL,
	valeurDecimal DECIMAL(30,10) NULL,
	valeurSpatiale geometry NULL
	CONSTRAINT [PK_DemandeValeurDynPropHistorique] PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE DemandeValeurDynPropHistorique  WITH CHECK ADD  CONSTRAINT [fk_DemandeValeurDynPropHistorique_demandeId] FOREIGN KEY([demandeId])
REFERENCES [Demande] ([id])

ALTER TABLE DemandeValeurDynPropHistorique  WITH CHECK ADD  CONSTRAINT [fk_DemandeValeurDynPropHistorique_demandeDynPropId] FOREIGN KEY([demandeDynPropId])
REFERENCES [DemandeDynProp] ([id])