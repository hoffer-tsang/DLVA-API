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