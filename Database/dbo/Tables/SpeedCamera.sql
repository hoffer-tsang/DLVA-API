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