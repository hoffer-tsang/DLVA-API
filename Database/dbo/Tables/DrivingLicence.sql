CREATE TABLE dbo.DrivingLicence
(
    OwnerId			INT NOT NULL,
    DriverNumber	VARCHAR(18) NOT NULL,

    CONSTRAINT		PK_DrivingLicence
        PRIMARY KEY	(OwnerId),

    CONSTRAINT		FK_DrivingLicence_Owner
        FOREIGN KEY	(OwnerId)
        REFERENCES	dbo.Owner (OwnerId),

    CONSTRAINT		UQ_DriverNumber 
		UNIQUE		(DriverNumber)
)