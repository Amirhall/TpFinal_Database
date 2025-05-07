USE BD_WRC
GO


CREATE SCHEMA Equipes;
GO
CREATE SCHEMA Rallyes;
GO


CREATE TABLE Equipes.Voiture (
    VoitureID INT IDENTITY(1,1) NOT NULL,
    Marque NVARCHAR(50) NOT NULL,
    Modele NVARCHAR(50) NOT NULL,
    Annee INT NOT NULL,
    Traction NVARCHAR(20) NOT NULL,
    Moteur NVARCHAR(50) NOT NULL,
    Poids INT NOT NULL,
    Vitesse_maximal DECIMAL(8,2) NOT NULL,
    Acceleration DECIMAL(8,2) NOT NULL,
    CONSTRAINT PK_Voiture_VoitureID PRIMARY KEY (VoitureID)
);

CREATE TABLE Equipes.Pilote (
    PiloteID INT IDENTITY(1,1) NOT NULL,
    Nom NVARCHAR(50) NOT NULL,
    Prenom NVARCHAR(50) NOT NULL,
    DateNaissance DATE NOT NULL,
    Nationalite NVARCHAR(50),
	EquipeID INT,
    CONSTRAINT PK_Pilote_PiloteID PRIMARY KEY (PiloteID)
);

CREATE TABLE Equipes.Equipe (
    EquipeID INT IDENTITY(1,1) NOT NULL,
    Nom NVARCHAR(50) NOT NULL,
    Constructeur NVARCHAR(50),
	VoitureID INT NOT NULL,
    CONSTRAINT PK_Equipe_EquipeID PRIMARY KEY (EquipeID)
);

CREATE TABLE Rallyes.Rallye (
    RallyeID INT IDENTITY(1,1) NOT NULL,
    Nom NVARCHAR(100) NOT NULL,
    DateDebut DATE NOT NULL,
    DateFin DATE NOT NULL,
    Ville NVARCHAR(100) NOT NULL,
	Pays NVARCHAR(100) NOT NULL,
    Terrain NVARCHAR(50) NOT NULL,
    Distance DECIMAL(8,2),
    CONSTRAINT PK_Rallye_RallyeID PRIMARY KEY (RallyeID)
);

CREATE TABLE Rallyes.DetailRallye (
    DetailRallyeID INT IDENTITY(1,1) NOT NULL,
    RallyeID INT,
    EquipeID INT,
    CONSTRAINT PK_DetailRallye_DetailRallyeID PRIMARY KEY (DetailRallyeID)
);

CREATE TABLE Rallyes.Classement (
    ClassementID INT IDENTITY(1,1) NOT NULL,
    Position INT NOT NULL,
    Temps NVARCHAR(50) NOT NULL,
    EquipeID INT,
    VoitureID INT NOT NULL,
    PiloteID INT NOT NULL,
	RallyeID INT NOT NULL,
    CONSTRAINT PK_Classement_ClassementID PRIMARY KEY (ClassementID)
);

CREATE TABLE Equipes.Trophee (
    TropheeID INT IDENTITY(1,1) NOT NULL,
    NomTrophee NVARCHAR(100) NOT NULL,
	PiloteID INT NOT NULL,
    CONSTRAINT PK_Trophee_TropheeID PRIMARY KEY (TropheeID)
);





ALTER TABLE Equipes.Pilote
ADD CONSTRAINT FK_Pilote_EquipeID FOREIGN KEY (EquipeID) REFERENCES Equipes.Equipe(EquipeID);
GO


ALTER TABLE Rallyes.DetailRallye
ADD CONSTRAINT FK_DetailRallye_RallyeID FOREIGN KEY (RallyeID) REFERENCES Rallyes.Rallye(RallyeID),
CONSTRAINT FK_DetailRallye_EquipeID FOREIGN KEY (EquipeID) REFERENCES Equipes.Equipe(EquipeID);
GO
ALTER TABLE Rallyes.Classement
ADD CONSTRAINT FK_Classement_EquipeID FOREIGN KEY (EquipeID) REFERENCES Equipes.Equipe(EquipeID),
CONSTRAINT FK_Classement_VoitureID FOREIGN KEY (VoitureID) REFERENCES Equipes.Voiture(VoitureID),
CONSTRAINT FK_Classement_PiloteID FOREIGN KEY (PiloteID) REFERENCES Equipes.Pilote(PiloteID),
CONSTRAINT FK_Classement_RallyeID FOREIGN KEY (RallyeID) REFERENCES Rallyes.Rallye(RallyeID);
GO
ALTER TABLE Equipes.Trophee
ADD CONSTRAINT FK_Trophee_PiloteID FOREIGN KEY (PiloteID) REFERENCES Equipes.Pilote(PiloteID);
GO

ALTER TABLE Equipes.Equipe
ADD CONSTRAINT FK_Equipe_VoitureID FOREIGN KEY (VoitureID) REFERENCES Equipes.Voiture(VoitureID);
GO