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