
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2016 20:45:25
-- Generated from EDMX file: C:\WorkSpace\Review\Web\Review\Model\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Review];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ScoreBandReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_ScoreBandReview];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewerReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_ReviewerReview];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_CountryCity];
GO
IF OBJECT_ID(N'[dbo].[FK_CityAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_CityAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryReviewer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Reviewer] DROP CONSTRAINT [FK_CountryReviewer];
GO
IF OBJECT_ID(N'[dbo].[FK_CityReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_CityReview];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_CountryReview];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_CategoryCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_CategoryTag];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_BusinessAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_BusinessTag];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_BusinessReview];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessOwner_Business]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessOwner] DROP CONSTRAINT [FK_BusinessOwner_Business];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessOwner_Owner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessOwner] DROP CONSTRAINT [FK_BusinessOwner_Owner];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_ReviewTag];
GO
IF OBJECT_ID(N'[dbo].[FK_Reviewer_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Reviewer] DROP CONSTRAINT [FK_Reviewer_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Owner_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Owner] DROP CONSTRAINT [FK_Owner_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Admin_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Admin] DROP CONSTRAINT [FK_Admin_inherits_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[Businesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Businesses];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO
IF OBJECT_ID(N'[dbo].[ScoreBands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScoreBands];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Users_Reviewer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Reviewer];
GO
IF OBJECT_ID(N'[dbo].[Users_Owner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Owner];
GO
IF OBJECT_ID(N'[dbo].[Users_Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Admin];
GO
IF OBJECT_ID(N'[dbo].[BusinessOwner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessOwner];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Family] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Password] nvarchar(20)  NULL,
    [RegisterationDateTime] datetime  NOT NULL,
    [IsActivate] bit  NOT NULL,
    [ActivationType] tinyint  NOT NULL,
    [ActivationDateTime] datetime  NULL,
    [Status] smallint  NOT NULL,
    [Salt] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] uniqueidentifier  NOT NULL,
    [TagName] nvarchar(max)  NOT NULL,
    [Searchable] bit  NOT NULL,
    [Category_Id] int  NULL,
    [Business_Id] uniqueidentifier  NULL,
    [Review_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Businesses'
CREATE TABLE [dbo].[Businesses] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [Logo] nvarchar(max)  NOT NULL,
    [Bio] nvarchar(max)  NOT NULL,
    [AverageScore] smallint  NOT NULL,
    [LastCalculationDateTime] datetime  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Status] smallint  NOT NULL,
    [Code] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [Id] uniqueidentifier  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [SubmitDateTime] nvarchar(max)  NOT NULL,
    [SubmitIP] nvarchar(max)  NOT NULL,
    [SubmitLatitude] nvarchar(max)  NOT NULL,
    [SubmitLongitude] nvarchar(max)  NOT NULL,
    [IsConfirm] nvarchar(max)  NOT NULL,
    [Type] smallint  NOT NULL,
    [IsAnonymous] bit  NOT NULL,
    [ToBlackList] bit  NOT NULL,
    [ScoreBand_Id] smallint  NOT NULL,
    [Reviewer_Id] uniqueidentifier  NOT NULL,
    [City_Id] int  NULL,
    [Location_Id] int  NULL,
    [Business_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ScoreBands'
CREATE TABLE [dbo].[ScoreBands] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Star] nvarchar(max)  NOT NULL,
    [Score] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] uniqueidentifier  NOT NULL,
    [AddressLine1] nvarchar(200)  NOT NULL,
    [AddressLine2] nvarchar(200)  NOT NULL,
    [PostCode] nvarchar(20)  NOT NULL,
    [TelNo] nvarchar(20)  NOT NULL,
    [FaxNo] nvarchar(20)  NOT NULL,
    [Location] geography  NOT NULL,
    [City_Id] int  NOT NULL,
    [Business_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Status] smallint  NOT NULL,
    [Code] nvarchar(10)  NOT NULL,
    [Country_Id] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [Bio] nvarchar(max)  NOT NULL,
    [Logo] nvarchar(max)  NOT NULL,
    [Parent_Id] int  NULL
);
GO

-- Creating table 'Users_Reviewer'
CREATE TABLE [dbo].[Users_Reviewer] (
    [RegisterationSource] tinyint  NOT NULL,
    [LastCommentDateTime] datetime  NULL,
    [Gender] smallint  NOT NULL,
    [Bio] nvarchar(max)  NOT NULL,
    [BirthDay] nvarchar(max)  NOT NULL,
    [Interest] nvarchar(max)  NOT NULL,
    [EducationDegree] smallint  NOT NULL,
    [Id] uniqueidentifier  NOT NULL,
    [Country_Id] int  NULL
);
GO

-- Creating table 'Users_Owner'
CREATE TABLE [dbo].[Users_Owner] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users_Admin'
CREATE TABLE [dbo].[Users_Admin] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BusinessOwner'
CREATE TABLE [dbo].[BusinessOwner] (
    [Business_Id] uniqueidentifier  NOT NULL,
    [Owners_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Businesses'
ALTER TABLE [dbo].[Businesses]
ADD CONSTRAINT [PK_Businesses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScoreBands'
ALTER TABLE [dbo].[ScoreBands]
ADD CONSTRAINT [PK_ScoreBands]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Reviewer'
ALTER TABLE [dbo].[Users_Reviewer]
ADD CONSTRAINT [PK_Users_Reviewer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Owner'
ALTER TABLE [dbo].[Users_Owner]
ADD CONSTRAINT [PK_Users_Owner]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Admin'
ALTER TABLE [dbo].[Users_Admin]
ADD CONSTRAINT [PK_Users_Admin]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Business_Id], [Owners_Id] in table 'BusinessOwner'
ALTER TABLE [dbo].[BusinessOwner]
ADD CONSTRAINT [PK_BusinessOwner]
    PRIMARY KEY CLUSTERED ([Business_Id], [Owners_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ScoreBand_Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_ScoreBandReview]
    FOREIGN KEY ([ScoreBand_Id])
    REFERENCES [dbo].[ScoreBands]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScoreBandReview'
CREATE INDEX [IX_FK_ScoreBandReview]
ON [dbo].[Reviews]
    ([ScoreBand_Id]);
GO

-- Creating foreign key on [Reviewer_Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_ReviewerReview]
    FOREIGN KEY ([Reviewer_Id])
    REFERENCES [dbo].[Users_Reviewer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewerReview'
CREATE INDEX [IX_FK_ReviewerReview]
ON [dbo].[Reviews]
    ([Reviewer_Id]);
GO

-- Creating foreign key on [Country_Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_CountryCity]
    FOREIGN KEY ([Country_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryCity'
CREATE INDEX [IX_FK_CountryCity]
ON [dbo].[Cities]
    ([Country_Id]);
GO

-- Creating foreign key on [City_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_CityAddress]
    FOREIGN KEY ([City_Id])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityAddress'
CREATE INDEX [IX_FK_CityAddress]
ON [dbo].[Addresses]
    ([City_Id]);
GO

-- Creating foreign key on [Country_Id] in table 'Users_Reviewer'
ALTER TABLE [dbo].[Users_Reviewer]
ADD CONSTRAINT [FK_CountryReviewer]
    FOREIGN KEY ([Country_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryReviewer'
CREATE INDEX [IX_FK_CountryReviewer]
ON [dbo].[Users_Reviewer]
    ([Country_Id]);
GO

-- Creating foreign key on [City_Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_CityReview]
    FOREIGN KEY ([City_Id])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityReview'
CREATE INDEX [IX_FK_CityReview]
ON [dbo].[Reviews]
    ([City_Id]);
GO

-- Creating foreign key on [Location_Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_CountryReview]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryReview'
CREATE INDEX [IX_FK_CountryReview]
ON [dbo].[Reviews]
    ([Location_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_CategoryCategory]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCategory'
CREATE INDEX [IX_FK_CategoryCategory]
ON [dbo].[Categories]
    ([Parent_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [FK_CategoryTag]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryTag'
CREATE INDEX [IX_FK_CategoryTag]
ON [dbo].[Tags]
    ([Category_Id]);
GO

-- Creating foreign key on [Business_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_BusinessAddress]
    FOREIGN KEY ([Business_Id])
    REFERENCES [dbo].[Businesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessAddress'
CREATE INDEX [IX_FK_BusinessAddress]
ON [dbo].[Addresses]
    ([Business_Id]);
GO

-- Creating foreign key on [Business_Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [FK_BusinessTag]
    FOREIGN KEY ([Business_Id])
    REFERENCES [dbo].[Businesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessTag'
CREATE INDEX [IX_FK_BusinessTag]
ON [dbo].[Tags]
    ([Business_Id]);
GO

-- Creating foreign key on [Business_Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_BusinessReview]
    FOREIGN KEY ([Business_Id])
    REFERENCES [dbo].[Businesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessReview'
CREATE INDEX [IX_FK_BusinessReview]
ON [dbo].[Reviews]
    ([Business_Id]);
GO

-- Creating foreign key on [Business_Id] in table 'BusinessOwner'
ALTER TABLE [dbo].[BusinessOwner]
ADD CONSTRAINT [FK_BusinessOwner_Business]
    FOREIGN KEY ([Business_Id])
    REFERENCES [dbo].[Businesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Owners_Id] in table 'BusinessOwner'
ALTER TABLE [dbo].[BusinessOwner]
ADD CONSTRAINT [FK_BusinessOwner_Owner]
    FOREIGN KEY ([Owners_Id])
    REFERENCES [dbo].[Users_Owner]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessOwner_Owner'
CREATE INDEX [IX_FK_BusinessOwner_Owner]
ON [dbo].[BusinessOwner]
    ([Owners_Id]);
GO

-- Creating foreign key on [Review_Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [FK_ReviewTag]
    FOREIGN KEY ([Review_Id])
    REFERENCES [dbo].[Reviews]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewTag'
CREATE INDEX [IX_FK_ReviewTag]
ON [dbo].[Tags]
    ([Review_Id]);
GO

-- Creating foreign key on [Id] in table 'Users_Reviewer'
ALTER TABLE [dbo].[Users_Reviewer]
ADD CONSTRAINT [FK_Reviewer_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Users_Owner'
ALTER TABLE [dbo].[Users_Owner]
ADD CONSTRAINT [FK_Owner_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Users_Admin'
ALTER TABLE [dbo].[Users_Admin]
ADD CONSTRAINT [FK_Admin_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------