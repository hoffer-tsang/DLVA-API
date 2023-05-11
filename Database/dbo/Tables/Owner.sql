CREATE TABLE dbo.Owner
(
    OwnerId			INT IDENTITY(1, 1) NOT NULL,
    FirstName		VARCHAR(40) NOT NULL,
    LastName		VARCHAR(40) NOT NULL,
    DateOfBirth		DATE NOT NULL,
    AddressId		INT NOT NULL,
    
	[RowVersion] ROWVERSION NOT NULL, 
    CONSTRAINT		PK_Owner
        PRIMARY KEY	(OwnerId),

    CONSTRAINT		FK_Owner_Address
        FOREIGN KEY	(AddressId)
        REFERENCES	dbo.Address (AddressId)
)