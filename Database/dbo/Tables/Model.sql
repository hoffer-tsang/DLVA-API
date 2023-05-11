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