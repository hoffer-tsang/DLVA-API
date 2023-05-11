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
GO

CREATE TABLE dbo.Owner
(
    OwnerId			INT IDENTITY(1, 1) NOT NULL,
    FirstName		VARCHAR(40) NOT NULL,
    LastName		VARCHAR(40) NOT NULL,
    DateOfBirth		DATE NOT NULL,
    AddressId		INT NOT NULL,
    
	CONSTRAINT		PK_Owner
        PRIMARY KEY	(OwnerId),

    CONSTRAINT		FK_Owner_Address
        FOREIGN KEY	(AddressId)
        REFERENCES	dbo.Address (AddressId)
)
GO

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
GO

CREATE TABLE dbo.LicenceCategory
(
    LicenceCategoryId	INT NOT NULL,
    MinimumAge			INT NOT NULL,
    Name				VARCHAR(20) NOT NULL,
    
	CONSTRAINT		PK_LicenceCategory
		PRIMARY KEY	(LicenceCategoryId)
)
GO

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
GO

CREATE TABLE dbo.Make
(
	MakeId			INT IDENTITY(1,1) NOT NULL,
	Name			NVARCHAR(50)

	CONSTRAINT			PK_Make
        PRIMARY KEY		(MakeId)
)

CREATE TABLE dbo.Model
(
	ModelId			INT IDENTITY(1,1) NOT NULL,
	MakeId			INT,
	Name			NVARCHAR(50)

	CONSTRAINT			PK_Model
        PRIMARY KEY		(ModelId),

	 CONSTRAINT			FK_Model_Make
		FOREIGN KEY		(MakeId)
        REFERENCES		dbo.Make (MakeId)
)

CREATE TABLE dbo.Colour
(
	ColourId	INT IDENTITY(1,1) NOT NULL,
	Name		NVARCHAR(50)

	CONSTRAINT			PK_Colour
        PRIMARY KEY		(ColourId)
)


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
        FOREIGN KEY		(OwnerID)
        REFERENCES		dbo.Owner (OwnerId),
	CONSTRAINT			FK_Car_Model
        FOREIGN KEY		(ModelId)
        REFERENCES		dbo.Model (ModelId),
	CONSTRAINT			FK_Car_Colour
        FOREIGN KEY		(ColourId)
        REFERENCES		dbo.Colour (ColourId)
)
GO

CREATE TABLE dbo.Camera
(
    CameraId			INT IDENTITY(1, 1) NOT NULL,
	RoadName			VARCHAR(50) NOT NULL,
	RoadNumber			VARCHAR(5) NULL,
    Longitude			DECIMAL(8,5) NOT NULL,
    Latitude			DECIMAL(8,5) NOT NULL,
    AddressId			INT NULL,

    CONSTRAINT			PK_Camera
        PRIMARY KEY		(CameraId),

    CONSTRAINT			FK_Camera_Address
        FOREIGN KEY		(AddressId)
        REFERENCES		dbo.Address (AddressId)
)
GO

CREATE TABLE dbo.TrafficLightCamera
(
    CameraId						INT NOT NULL,
    SecondsAfterRedLightThreshold	TINYINT NOT NULL,
    
	CONSTRAINT						PK_TrafficLightCamera
			PRIMARY KEY				(CameraId),

    CONSTRAINT						FK_TrafficLightCamera_Camera
        FOREIGN KEY					(CameraId)
        REFERENCES					dbo.Camera (CameraId)
)
GO

CREATE TABLE dbo.SpeedCamera
(
    CameraId			INT NOT NULL,
    SpeedMphLimit		TINYINT NOT NULL,

    CONSTRAINT			PK_SpeedCamera
        PRIMARY KEY		(CameraId),

    CONSTRAINT			FK_SpeedCamera_Camera
        FOREIGN KEY		(CameraId)
        REFERENCES		dbo.Camera (CameraId)
)
GO

CREATE TABLE dbo.Sighting
(
    SightingId				INT IDENTITY(1, 1) NOT NULL,
    CarId					INT NOT NULL,
    CameraId				INT NOT NULL,
    SightingTime			DATETIME2 NOT NULL,
    SecondsAfterRedLight	TINYINT NULL,
    SpeedMph				TINYINT NULL,

    CONSTRAINT				PK_Sighting
        PRIMARY KEY			(SightingId),

    CONSTRAINT				FK_Sighting_Car
        FOREIGN KEY			(CarId)
        REFERENCES			dbo.Car (CarId),

    CONSTRAINT				FK_Sighting_Camera
        FOREIGN KEY			(CameraId)
        REFERENCES			dbo.Camera (CameraId)
)
GO


CREATE TABLE dbo.Fine
(
    SightingId		INT NOT NULL,
    DateIssued		DATE NOT NULL DEFAULT GETDATE(),
    DatePaid		DATE NULL,

    CONSTRAINT		PK_Fine
        PRIMARY KEY (SightingId),

    Constraint		FK_Fine_Sighting
        FOREIGN KEY	(SightingId)
        REFERENCES	dbo.Sighting (SightingId) 
)
GO
