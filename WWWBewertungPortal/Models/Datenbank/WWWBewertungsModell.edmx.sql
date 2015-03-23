
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2015 18:04:19
-- Generated from EDMX file: H:\Master_2014\Cloud Computing\CSharpWebProjekt\NeuWeb\WWWBewertungPortal\Models\Datenbank\WWWBewertungsModell.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_BewertungPotal_TestLo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Tab_LokationTab_Bewertung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tab_BewertungSet] DROP CONSTRAINT [FK_Tab_LokationTab_Bewertung];
GO
IF OBJECT_ID(N'[dbo].[FK_Tab_BenutzerTab_Bewertung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tab_BewertungSet] DROP CONSTRAINT [FK_Tab_BenutzerTab_Bewertung];
GO
IF OBJECT_ID(N'[dbo].[FK_Tab_BenutzerTab_Kommentar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tab_KommentarSet] DROP CONSTRAINT [FK_Tab_BenutzerTab_Kommentar];
GO
IF OBJECT_ID(N'[dbo].[FK_Tab_BewertungTab_Kommentar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tab_KommentarSet] DROP CONSTRAINT [FK_Tab_BewertungTab_Kommentar];
GO
IF OBJECT_ID(N'[dbo].[FK_Tab_Lokation_PhotoTab_Lokation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tab_Lokation_PhotoSet] DROP CONSTRAINT [FK_Tab_Lokation_PhotoTab_Lokation];
GO
IF OBJECT_ID(N'[dbo].[FK_Tab_AvartarPhotoTab_Benutzer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tab_AvartarPhotoSet] DROP CONSTRAINT [FK_Tab_AvartarPhotoTab_Benutzer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Tab_BenutzerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tab_BenutzerSet];
GO
IF OBJECT_ID(N'[dbo].[Tab_LokationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tab_LokationSet];
GO
IF OBJECT_ID(N'[dbo].[Tab_Lokation_PhotoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tab_Lokation_PhotoSet];
GO
IF OBJECT_ID(N'[dbo].[Tab_KommentarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tab_KommentarSet];
GO
IF OBJECT_ID(N'[dbo].[Tab_BewertungSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tab_BewertungSet];
GO
IF OBJECT_ID(N'[dbo].[Tab_AvartarPhotoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tab_AvartarPhotoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tab_BenutzerSet'
CREATE TABLE [dbo].[Tab_BenutzerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Passwort] nvarchar(max)  NOT NULL,
    [Geschlecht] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tab_LokationSet'
CREATE TABLE [dbo].[Tab_LokationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adresse] nvarchar(max)  NOT NULL,
    [Lat] nvarchar(max)  NOT NULL,
    [Lng] nvarchar(max)  NOT NULL,
    [Place_id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tab_Lokation_PhotoSet'
CREATE TABLE [dbo].[Tab_Lokation_PhotoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [Tab_LokationId] int  NOT NULL
);
GO

-- Creating table 'Tab_KommentarSet'
CREATE TABLE [dbo].[Tab_KommentarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Datum] nvarchar(max)  NOT NULL,
    [Tab_Benutzer_Id] int  NOT NULL,
    [Tab_Bewertung_Id] int  NOT NULL
);
GO

-- Creating table 'Tab_BewertungSet'
CREATE TABLE [dbo].[Tab_BewertungSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ueberschrift] nvarchar(max)  NOT NULL,
    [Inhalt] nvarchar(max)  NOT NULL,
    [Erstelltlungdatum] nvarchar(max)  NOT NULL,
    [Voting] nvarchar(max)  NOT NULL,
    [Tab_Lokation_Id] int  NOT NULL,
    [Tab_Benutzer_Id] int  NOT NULL
);
GO

-- Creating table 'Tab_AvartarPhotoSet'
CREATE TABLE [dbo].[Tab_AvartarPhotoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [Tab_Benutzer_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Tab_BenutzerSet'
ALTER TABLE [dbo].[Tab_BenutzerSet]
ADD CONSTRAINT [PK_Tab_BenutzerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tab_LokationSet'
ALTER TABLE [dbo].[Tab_LokationSet]
ADD CONSTRAINT [PK_Tab_LokationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tab_Lokation_PhotoSet'
ALTER TABLE [dbo].[Tab_Lokation_PhotoSet]
ADD CONSTRAINT [PK_Tab_Lokation_PhotoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tab_KommentarSet'
ALTER TABLE [dbo].[Tab_KommentarSet]
ADD CONSTRAINT [PK_Tab_KommentarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tab_BewertungSet'
ALTER TABLE [dbo].[Tab_BewertungSet]
ADD CONSTRAINT [PK_Tab_BewertungSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tab_AvartarPhotoSet'
ALTER TABLE [dbo].[Tab_AvartarPhotoSet]
ADD CONSTRAINT [PK_Tab_AvartarPhotoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Tab_Lokation_Id] in table 'Tab_BewertungSet'
ALTER TABLE [dbo].[Tab_BewertungSet]
ADD CONSTRAINT [FK_Tab_LokationTab_Bewertung]
    FOREIGN KEY ([Tab_Lokation_Id])
    REFERENCES [dbo].[Tab_LokationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tab_LokationTab_Bewertung'
CREATE INDEX [IX_FK_Tab_LokationTab_Bewertung]
ON [dbo].[Tab_BewertungSet]
    ([Tab_Lokation_Id]);
GO

-- Creating foreign key on [Tab_Benutzer_Id] in table 'Tab_BewertungSet'
ALTER TABLE [dbo].[Tab_BewertungSet]
ADD CONSTRAINT [FK_Tab_BenutzerTab_Bewertung]
    FOREIGN KEY ([Tab_Benutzer_Id])
    REFERENCES [dbo].[Tab_BenutzerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tab_BenutzerTab_Bewertung'
CREATE INDEX [IX_FK_Tab_BenutzerTab_Bewertung]
ON [dbo].[Tab_BewertungSet]
    ([Tab_Benutzer_Id]);
GO

-- Creating foreign key on [Tab_Benutzer_Id] in table 'Tab_KommentarSet'
ALTER TABLE [dbo].[Tab_KommentarSet]
ADD CONSTRAINT [FK_Tab_BenutzerTab_Kommentar]
    FOREIGN KEY ([Tab_Benutzer_Id])
    REFERENCES [dbo].[Tab_BenutzerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tab_BenutzerTab_Kommentar'
CREATE INDEX [IX_FK_Tab_BenutzerTab_Kommentar]
ON [dbo].[Tab_KommentarSet]
    ([Tab_Benutzer_Id]);
GO

-- Creating foreign key on [Tab_Bewertung_Id] in table 'Tab_KommentarSet'
ALTER TABLE [dbo].[Tab_KommentarSet]
ADD CONSTRAINT [FK_Tab_BewertungTab_Kommentar]
    FOREIGN KEY ([Tab_Bewertung_Id])
    REFERENCES [dbo].[Tab_BewertungSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tab_BewertungTab_Kommentar'
CREATE INDEX [IX_FK_Tab_BewertungTab_Kommentar]
ON [dbo].[Tab_KommentarSet]
    ([Tab_Bewertung_Id]);
GO

-- Creating foreign key on [Tab_LokationId] in table 'Tab_Lokation_PhotoSet'
ALTER TABLE [dbo].[Tab_Lokation_PhotoSet]
ADD CONSTRAINT [FK_Tab_Lokation_PhotoTab_Lokation]
    FOREIGN KEY ([Tab_LokationId])
    REFERENCES [dbo].[Tab_LokationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tab_Lokation_PhotoTab_Lokation'
CREATE INDEX [IX_FK_Tab_Lokation_PhotoTab_Lokation]
ON [dbo].[Tab_Lokation_PhotoSet]
    ([Tab_LokationId]);
GO

-- Creating foreign key on [Tab_Benutzer_Id] in table 'Tab_AvartarPhotoSet'
ALTER TABLE [dbo].[Tab_AvartarPhotoSet]
ADD CONSTRAINT [FK_Tab_AvartarPhotoTab_Benutzer]
    FOREIGN KEY ([Tab_Benutzer_Id])
    REFERENCES [dbo].[Tab_BenutzerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tab_AvartarPhotoTab_Benutzer'
CREATE INDEX [IX_FK_Tab_AvartarPhotoTab_Benutzer]
ON [dbo].[Tab_AvartarPhotoSet]
    ([Tab_Benutzer_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------