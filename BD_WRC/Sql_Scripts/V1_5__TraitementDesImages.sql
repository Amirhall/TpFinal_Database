CREATE TABLE Equipes.PhotoPilote(
	PhotoPiloteID int IDENTITY(1,1) NOT NULL,
	Identifiant uniqueidentifier NOT NULL ROWGUIDCOL,
	PiloteID int
	CONSTRAINT PK_PhotoPilote_PhotoPiloteID PRIMARY KEY (PhotoPiloteID)
)
GO
ALTER TABLE Equipes.PhotoPilote ADD CONSTRAINT UC_PhotoPilote_Identifiant
UNIQUE (Identifiant);
GO
ALTER TABLE Equipes.PhotoPilote ADD CONSTRAINT DF_PhotoPilote_Identifiant
DEFAULT newid() FOR Identifiant;
GO
ALTER TABLE Equipes.PhotoPilote ADD
PilotePhotoContent varbinary(MAX) FILESTREAM NULL;
GO

-- AJOUT du lien de clé étrangère
ALTER TABLE Equipes.PhotoPilote ADD CONSTRAINT FK_PhotoPilote_PiloteID
FOREIGN KEY (PiloteID)
references Equipes.Pilote(PiloteID)
GO

INSERT INTO Spectacles.Affiche(SpectacleID, AfficheContent)
SELECT 1, BulkColumn FROM OPENROWSET(
	BULK 'What do I put here/image.png', SINGLE_BLOB) AS myfile;
