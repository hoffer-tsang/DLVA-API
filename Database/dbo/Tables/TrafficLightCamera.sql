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