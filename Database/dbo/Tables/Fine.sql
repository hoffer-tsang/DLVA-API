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