CREATE TABLE dbo.Car
(
    CarId				INT IDENTITY(1, 1) NOT NULL,
    RegistrationNumber	VARCHAR(7) NOT NULL,
    ColourId			INT NOT NULL,
	ModelId				INT NOT NULL,
    RegistrationDate	DATE NOT NULL,
    OwnerId				INT NOT NULL,
    
	CONSTRAINT			PK_Car
        PRIMARY KEY		(CarId),
    CONSTRAINT			UQ_Car 
		UNIQUE			(RegistrationNumber),
    CONSTRAINT			FK_Car_Owner
        FOREIGN KEY		(OwnerId)
        REFERENCES		dbo.Owner (OwnerId),
	CONSTRAINT			FK_Car_Model
        FOREIGN KEY		(ModelId)
        REFERENCES		dbo.Model (ModelId),
	CONSTRAINT			FK_Car_Colour
        FOREIGN KEY		(ColourId)
        REFERENCES		dbo.Colour (ColourId)
)