USE BD_WRC
GO

CREATE OR ALTER PROCEDURE Equipes.USP_ConsultationCoursesPilote
(
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@DateDebut Date,
	@DateFin Date
)
AS
BEGIN
	
	SELECT C.Position, P.Nom AS NomPilote, P.Prenom, V.Marque ,V.Modele, E.Nom as Equipe, C.Temps, R.Nom as Course, R.DateDebut,R.DateFin
	FROM Rallyes.Classement C
	INNER JOIN Equipes.Equipe E ON C.EquipeID = E.EquipeID
	INNER JOIN Equipes.Voiture V ON C.VoitureID = V.VoitureID
	INNER JOIN Equipes.Pilote P ON C.PiloteID = P.PiloteID
	INNER JOIN Rallyes.Rallye R ON C.RallyeID = R.RallyeID
	WHERE P.Nom = @Nom AND P.Prenom = @Prenom
	AND R.DateDebut BETWEEN  @DateDebut AND @DateFin

END
GO

