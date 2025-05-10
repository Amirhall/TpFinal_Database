USE BD_WRC
GO


--Liste des voitures qui ont une vitesse maximale supérieure à la moyenne de la vitesse maximale de toutes les voitures.
CREATE OR ALTER VIEW Rallyes.vw_PilotesStatistiquesAvancees AS
SELECT
    P.PiloteID,
    P.Nom,
    P.Prenom,
    P.Nationalite,
    COUNT(C.ClassementID) AS NombreParticipations,
    SUM(CASE WHEN C.Position = 1 THEN 1 ELSE 0 END) AS NombreVictoires,
    MIN(C.Position) AS MeilleurePosition,
    AVG(C.Position * 1.0) AS PositionMoyenne,
    E.Nom AS NomEquipe
FROM Equipes.Pilote P
INNER JOIN Rallyes.Classement C ON P.PiloteID = C.PiloteID
INNER JOIN Equipes.Equipe E ON E.EquipeID = P.EquipeID
GROUP BY 
    P.PiloteID, P.Nom, P.Prenom, P.Nationalite, E.Nom;
GO

CREATE OR ALTER VIEW Rallyes.VwCoursesPilote AS
SELECT
    c.Position,
    p.Nom AS NomPilote,
    p.Prenom,
    v.Marque,
    v.Modele,
    e.Nom AS Equipe,
    c.Temps,
    r.Nom AS Course,
    r.DateDebut,
    r.DateFin
FROM 
    Rallyes.Classement c
    INNER JOIN Equipes.Pilote p ON c.PiloteId = p.PiloteID
    INNER JOIN Equipes.Voiture v ON c.VoitureId = v.VoitureID
    INNER JOIN Equipes.Equipe e ON c.EquipeId = e.EquipeID
    INNER JOIN Rallyes.Rallye r ON c.RallyeId = r.RallyeID;
GO
