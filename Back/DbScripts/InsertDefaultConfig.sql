INSERT INTO [dbo].[WorkflowState]
           ([stateName]
           ,[stateShortName]
           ,[stateDescription]
           ,[icon]
           ,[active])
     VALUES
           ('Création'
           ,'Création'
           ,'Création'
           ,''
           ,1)
GO

INSERT INTO [dbo].[WorkFlow]
           ([workflowName]
           ,[workflowShortName]
           ,[workflowDescription]
           ,[startStateId])

SELECT 'Default WorkFLow','Default','',id
from [WorkflowState]
WHERE [stateName] ='Création'
GO

INSERT INTO [dbo].[DemandType]
           (typeName
           ,typeInternalName
           ,typeShortName
           ,typeDescription
           ,[icon]
           ,[active]
           ,[workflowId])
SELECT 'TypeTest','TypeTest','Test','','',1,ID
FROM [WorkFlow]
WHERE [workflowName]='Default WorkFLow'

GO

INSERT INTO [dbo].[DemandType]
           (typeName
           ,typeInternalName
           ,typeShortName
           ,typeDescription
           ,[icon]
           ,[active]
           ,[workflowId])
SELECT 'TypeTest2','TypeTest2','Test2','','',1,ID
FROM [WorkFlow]
WHERE [workflowName]='Default WorkFLow'

GO

/*
INSERT INTO [dbo].[FormConfig]
           ([typeId]
           ,[title]
           ,[columnNumber]
           ,[active]
           ,[validationMessage]
           ,[cssClass]
           ,[behavior])

SELECT ID ,'Formulaire de test',2,1,'Ouias ça marche','',0
FROM [DemandType] WHERE [typeInternalName]='TypeTest'



INSERT INTO [dbo].[FormConfig]
           ([typeId]
           ,[title]
           ,[columnNumber]
           ,[active]
           ,[validationMessage]
           ,[cssClass]
           ,[behavior])

SELECT ID ,'Formulaire de test2',2,1,'Ouias ça marche2','',0
FROM [DemandType] WHERE [typeInternalName]='TypeTest2'




INSERT INTO [dbo].[FormGroup]
           ([formConfigId]
           ,Title
           ,[columnIndex]
           ,[groupOrder]
           ,[active]
           ,[cssClass]
		   ,behavior)
    SELECT id, 'Informations personnelles',1,1,1,'',0
	from [FormConfig] where [title]='Formulaire de test'


INSERT INTO [dbo].[FormField]
           ([formGroupId]
           ,[fieldName]
           ,[fieldType]
           ,[fieldLabel]
           ,[isDynamic]
           ,[fieldParameters]
           ,[fieldOrder]
           ,[tooltip]
           ,[defaultValue]
           ,[active]
           ,[workflowStateId]
           ,[cssClass]
           ,[behavior])
SELECT ID,'nom_prenom','inputText','Nom & Prénom',1,'{"required":true}',1,'Champ de saisie nom et prénom','toto',1,NULL,'',0
FROM [FormGroup] WHERE Title='Informations personnelles'
*/