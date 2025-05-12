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

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 19, BulkColumn FROM OPENROWSET( 
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Angelo-Medeghini.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 2, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\bernardini_patrick.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 28, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Carlos Sainz.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 18, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Colin_Mcrae.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 1, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Didiner Auriol.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 24, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Ed Ordynski.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 16, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Freddy Loix.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 9, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Fujimoto Yoshio.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 6, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Gianfranco_Cunico_-_Rallye_Sanremo_1994.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 25, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Gilberto Pianezzola.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 36, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Hartono Bambang.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 7, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Ian-Duncan.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 33, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Irvan Gading.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 12, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Jasson Gullabo.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 30, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Jonathan Toroitich.png', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 13, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Kankkunen Juha.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 27, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Kenjiro Shinozuka.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 8, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Kenneth-Eriksson.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 32, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Konishi Shigeyuki.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 14, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Liatti Piero.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 11, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Marcus_Gronholm.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 15, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Michael Lieu.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 21, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\miyoshi_hideaki.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 10, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\oriol.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 23, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Patrick-Njiru.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 4, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Possum.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 26, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\reza Pribadi.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 5, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Richard_Burns.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 17, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Rui-Madeira.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 3, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Stig.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 29, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Thiry Bruno.jpeg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 27, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\thomas Radstrom.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 20, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Tommi Makinen.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 31, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\uwe Wunsch.jpg', SINGLE_BLOB) AS myfile;

INSERT INTO Equipes.PhotoPilote(PiloteID, PilotePhotoContent)
SELECT 22, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\2284873\Documents\TpFinal_Database\BD_WRC\wwwroot\Photos des pilotes\Uwe-Nittel.jpg', SINGLE_BLOB) AS myfile;
