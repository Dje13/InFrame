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
           ([demandTypeName]
           ,[demandTypeInternalName]
           ,[demandTypeShortName]
           ,[demandTypeDescription]
           ,[icon]
           ,[active]
           ,[workflowId])
SELECT 'TypeTest','TypeTest','Test','','',1,ID
FROM [WorkFlow]
WHERE [workflowName]='Default WorkFLow'

GO

INSERT INTO [dbo].[DemandType]
           ([demandTypeName]
           ,[demandTypeInternalName]
           ,[demandTypeShortName]
           ,[demandTypeDescription]
           ,[icon]
           ,[active]
           ,[workflowId])
SELECT 'TypeTest2','TypeTest2','Test2','','',1,ID
FROM [WorkFlow]
WHERE [workflowName]='Default WorkFLow'

GO


INSERT INTO [dbo].[FormConfig]
           ([demandTypeId]
           ,[title]
           ,[columnNumber]
           ,[active]
           ,[validationMessage]
           ,[cssClass]
           ,[behavior])

SELECT ID ,' Formulaire de test',2,1,'Ouias ça marche','',0
FROM [DemandType] WHERE [demandTypeInternalName]='TypeTest'



INSERT INTO [dbo].[FormConfig]
           ([demandTypeId]
           ,[title]
           ,[columnNumber]
           ,[active]
           ,[validationMessage]
           ,[cssClass]
           ,[behavior])

SELECT ID ,' Formulaire de test2',2,1,'Ouias ça marche2','',0
FROM [DemandType] WHERE [demandTypeInternalName]='TypeTest2'