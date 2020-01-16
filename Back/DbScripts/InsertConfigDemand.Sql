



		   
INSERT INTO [dbo].[DemandType]
           (typeName
           ,typeInternalName
           ,typeShortName
           ,typeDescription
           ,[icon]
           ,[active]
           ,[workflowId])
SELECT 'Server','Server','Server','','',1,ID
FROM [WorkFlow]
WHERE [workflowName]='Default WorkFLow'


INSERT INTO [dbo].[DemandDynProp]
           ([dynPropName]
           ,[dynPropType]
           ,[active])
		   VALUES ('OperatingSystem','string',1) 


INSERT INTO [dbo].[DemandDynProp]
           ([dynPropName]
           ,[dynPropType]
           ,[active])
		   VALUES ('Role','string',1) 

INSERT INTO [dbo].[DemandDynProp]
           ([dynPropName]
           ,[dynPropType]
           ,[active])
		   VALUES ('Projet','string',1) 



INSERT INTO [dbo].[DemandDynProp]
           ([dynPropName]
           ,[dynPropType]
           ,[active])
		   VALUES ('CPU','int',1) 

INSERT INTO [dbo].[DemandDynProp]
           ([dynPropName]
           ,[dynPropType]
           ,[active])
		   VALUES ('RAM','int',1) 

INSERT INTO [dbo].[DemandType_DemandDynProp]
           ([dynPropId]
           ,[typeId]
           ,[active])
     SELECT P.ID,T.ID,1
	 FROM DemandType T JOIN  DemandDynProp P ON t.typeName='Server' and p.dynPropName in ('OperatingSystem','Role','Projet','CPU','RAM')


INSERT INTO [dbo].[FormConfig]
           ([typeId]
           ,[title]
           ,[columnNumber]
           ,[active]
           ,[validationMessage]
           ,[cssClass]
           ,[behavior])

SELECT ID ,'Demande de serveur',2,1,'La demande a bien été enregistrée','',0
FROM [DemandType] WHERE [typeInternalName]='Server'





INSERT INTO [dbo].[FormGroup]
           ([formConfigId]
           ,Title
           ,[columnIndex]
           ,[groupOrder]
           ,[active]
           ,[cssClass]
		   ,behavior)
    SELECT id, 'Contexte',1,1,1,'',0
	from [FormConfig] where [title]='Demande de serveur'


	INSERT INTO [dbo].[FormGroup]
           ([formConfigId]
           ,Title
           ,[columnIndex]
           ,[groupOrder]
           ,[active]
           ,[cssClass]
		   ,behavior)
    SELECT id, 'Informations techniques ',2,1,1,'',0
	from [FormConfig] where [title]='Demande de serveur'


	
INSERT INTO [dbo].[FormField] ([formGroupId],[fieldName],[fieldType],[fieldLabel],[isDynamic],[fieldParameters],[fieldOrder],[tooltip],[defaultValue],[active],[workflowStateId],[cssClass],[behavior])
SELECT ID,'Projet','inputText','Projet',1,'{"required":"true"}',1,'',null,1,null,'',0
from FormGroup where title ='Contexte'


INSERT INTO [dbo].[FormField] ([formGroupId],[fieldName],[fieldType],[fieldLabel],[isDynamic],[fieldParameters],[fieldOrder],[tooltip],[defaultValue],[active],[workflowStateId],[cssClass],[behavior])
SELECT ID,'Role','inputText','Rôle',1,'{"required":"true"}',1,'',null,1,null,'',0
from FormGroup where title ='Contexte'



