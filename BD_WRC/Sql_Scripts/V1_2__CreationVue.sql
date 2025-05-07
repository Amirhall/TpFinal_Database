USE BD_WRC
GO


--Liste des voitures qui ont une vitesse maximale supérieure à la moyenne de la vitesse maximale de toutes les voitures.
CREATE VIEW Rallyes.vw_VoituresVitesseMaxSupMoy
AS
    SELECT V.Marque, V.Modele, V.Annee, V.Vitesse_maximal AS [Vitesse maximale]
    FROM Equipes.Voiture V
    WHERE V.Vitesse_maximal > (
        SELECT AVG(Vitesse_maximal) 
        FROM Equipes.Voiture
    );
GO

CREATE OR ALTER VIEW Rallyes.VwCoursesPilote AS
SELECT 
    p.Nom AS NomPilote,
    p.Prenom,
    v.Marque,
    v.Modele,
    e.Nom AS Equipe,
    c.Temps,
    r.Nom AS NomRallye,
    CONVERT(varchar, r.DateDebut, 23) AS DateDebut,
    CONVERT(varchar, r.DateFin, 23) AS DateFin
FROM 
    Rallyes.Classement c
    INNER JOIN Equipes.Pilote p ON c.PiloteId = p.PiloteID
    INNER JOIN Equipes.Voiture v ON c.VoitureId = v.VoitureID
    INNER JOIN Equipes.Equipe e ON c.EquipeId = e.EquipeID
    INNER JOIN Rallyes.Rallye r ON c.RallyeId = r.RallyeID;
GO
