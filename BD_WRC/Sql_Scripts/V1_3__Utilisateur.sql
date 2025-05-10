CREATE SCHEMA Utilisateurs;
GO

CREATE TABLE Utilisateurs.Utilisateur(
	UtilisateurID int IDENTITY(1,1),
	Courriel nvarchar(256) NOT NULL,
	MotDePasseHache varbinary(32) NOT NULL,
	MdpSel varbinary(16) NOT NULL
	CONSTRAINT PK_Utilisateur_UtilisateurID PRIMARY KEY (UtilisateurID)

	
)
GO

ALTER TABLE Utilisateurs.Utilisateur
ADD CONSTRAINT UC_Utilisateur_Courriel UNIQUE (Courriel);
GO

-- Créer la procédure permettant à un client de s'enregistrer sur la plateforme
CREATE PROCEDURE Utilisateurs.USP_CreationCompte
    @Courriel nvarchar(256),
    @MotDePasse nvarchar(100)
AS
BEGIN

    DECLARE @Sel VARBINARY(16) = CRYPT_GEN_RANDOM(16); -- Génère un sel aléatoire de 16 octets
    DECLARE @MotDePasseCombine VARBINARY(MAX);         -- Concaténation mot de passe + sel
    DECLARE @MotDePasseHache VARBINARY(32);            -- SHA2_256 génère 32 octets

    -- Concaténer le mot de passe en clair et le sel
    SET @MotDePasseCombine = CONVERT(VARBINARY(MAX), @MotDePasse) + @Sel;

    -- Hacher le mot de passe combiné
    SET @MotDePasseHache = HASHBYTES('SHA2_256', @MotDePasseCombine);

    -- Insertion dans la table Client
    INSERT INTO Utilisateurs.Utilisateur (Courriel, MotDePasseHache, MdpSel)
    VALUES (@Courriel, @MotDePasseHache, @Sel);
END
GO

CREATE PROCEDURE Utilisateurs.USP_ConnexionCompte
	@Courriel nvarchar(256),
	@MotDePasse nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Sel varbinary(16);
    DECLARE @MdpHache varbinary(32);
    DECLARE @HacheEntre varbinary(32);

    SELECT @Sel = MdpSel, @MdpHache = MotDePasseHache
    FROM Utilisateurs.Utilisateur
    WHERE Courriel = @Courriel;

    IF @Sel IS NULL OR @MdpHache IS NULL
    BEGIN
        SELECT TOP 0 * FROM Utilisateurs.Utilisateur;
        RETURN;
    END

    SET @HacheEntre = HASHBYTES('SHA2_256', CONVERT(varbinary(max), @MotDePasse) + @Sel);

    IF @HacheEntre = @MdpHache
        SELECT * FROM Utilisateurs.Utilisateur WHERE Courriel = @Courriel;
    ELSE
        SELECT TOP 0 * FROM Utilisateurs.Utilisateur;
END
GO