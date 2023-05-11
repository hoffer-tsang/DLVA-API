CREATE TABLE dbo.LicenceEntitlement
(
    OwnerId				INT NOT NULL,
    LicenceCategoryId	INT NOT NULL,
    StartDate			DATE NOT NULL,
    ExpirationDate		DATE NOT NULL,

    CONSTRAINT			PK_LicenceEntitlement
		PRIMARY KEY		(OwnerId, LicenceCategoryId),

    CONSTRAINT			FK_LicenceEntitlement_DrivingLicence
        FOREIGN KEY		(OwnerId)
        REFERENCES		dbo.DrivingLicence (OwnerId),

    CONSTRAINT			FK_LicenceEntitlement_LicenceCategory
        FOREIGN KEY		(LicenceCategoryId)
        REFERENCES		dbo.LicenceCategory (LicenceCategoryId)
)