CREATE TABLE dbo.Colour
(
	ColourId	INT IDENTITY(1,1) NOT NULL,
	Name		NVARCHAR(50)

	CONSTRAINT			PK_Colour
        PRIMARY KEY		(ColourId)
)