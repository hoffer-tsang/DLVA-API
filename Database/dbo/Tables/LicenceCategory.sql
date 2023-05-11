CREATE TABLE dbo.LicenceCategory
(
    LicenceCategoryId	INT NOT NULL,
    MinimumAge			INT NOT NULL,
    Name				VARCHAR(20) NOT NULL,
    
	CONSTRAINT		PK_LicenceCategory
		PRIMARY KEY	(LicenceCategoryId)
)