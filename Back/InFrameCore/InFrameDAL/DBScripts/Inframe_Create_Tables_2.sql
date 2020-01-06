create table Form (
	id BIGINT IDENTITY(1,1) NOT NULL,
	title VARCHAR(50) NOT NULL,
	columnNumber INT NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	behavior INT NOT NULL --configurationLabel
)

create table FormGroup (
	id BIGINT IDENTITY(1,1) NOT NULL,	
	formId BIGINT NOT NULL,
	columnIndex INT NOT NULL,
	groupOrder INT NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	behavior INT NOT NULL, -- Label visible, bloc titre visible,type de groupe...
)


create table FormField (
	id BIGINT IDENTITY(1,1) NOT NULL,
	groupId BIGINT NOT NULL,
	demandTypeId BIGINT NOT NULL,
	fieldName VARCHAR(50) NOT NULL,
	fieldType VARCHAR(50) NOT NULL,
	fieldLabel VARCHAR(50) NOT NULL,
	isDynamic BIT NOT NULL,
	fieldParameters VARCHAR(MAX) NOT NULL, --(min, max, size, placeholder, disabled, ...)
	fieldOrder INT NOT NULL,
	tooltip VARCHAR(50) NOT NULL, --équivalent title html
	defaultValue VARCHAR(50) NOT NULL,
	active BIT NOT NULL, -- actif/inactif
	workflowState BIGINT NULL,
	behavior INT NOT NULL -- Label visible, ...
)







--permet de gérer contenu, position et état

/*

-- Tables où sont stockées les données de configuration des formulaires parametrés

(T) - Formulaire
- titre
- description
- nombre de colonnes
- position label champ (en haut ou à gauche)
- 

(T) - FormGroupe
- titre
- GroupType: Fieldset, carte , etc
- bloc titre visible => comportement
- visible=> comportement
- formulaire id
- colonne position
- nombre de colonnes => NOK 
- ordre

(T) - FormChamp
- label
- label visible
- obligatoire
- groupe id
- colonne position
- visible
- name
- options (select)
- contraintes (min, max, size, placeholder, disabled, ...)
- ordre
- element
- element type

(T) - FormReponse
- 

-- Tables où sont stockés les éléments génériques pouvant être utilisés dans les formulaires

(T) - FormGenElement
- input
- textarea
- select

(T) - FormGenInputType
- text
- number
- checkbox
- radio
- tel
- email
- password
- date
- month
- week
- time
- url
- file
- submit
- range
- search
- reset
- color


*/