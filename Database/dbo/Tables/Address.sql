CREATE TABLE dbo.Address
(
    AddressId		INT IDENTITY(1, 1) NOT NULL,
    Line1			VARCHAR(100) NOT NULL,
    Line2			VARCHAR(100) NULL,
    Line3			VARCHAR(100) NULL,
    City			VARCHAR(50) NOT NULL,
    County			VARCHAR(50) NOT NULL,
    Country			VARCHAR(50)  NOT NULL,
    PostalCode		VARCHAR(16) NOT NULL,
   
   CONSTRAINT		PK_Address
		PRIMARY KEY	(AddressId)
)