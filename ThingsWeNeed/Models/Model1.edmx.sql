
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/27/2019 16:00:34
-- Generated from EDMX file: C:\Repos\ThingsWeNeed\ThingsWeNeed\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ThingsWeNeedTestDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ThingHousehold]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_ThingHousehold];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseAppUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_PurchaseAppUser];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseholdAppUser_Household]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HouseholdAppUser] DROP CONSTRAINT [FK_HouseholdAppUser_Household];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseholdAppUser_AppUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HouseholdAppUser] DROP CONSTRAINT [FK_HouseholdAppUser_AppUser];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseHousehold]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_PurchaseHousehold];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseThing]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Things] DROP CONSTRAINT [FK_PurchaseThing];
GO
IF OBJECT_ID(N'[dbo].[FK_AppUserWish]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wishes] DROP CONSTRAINT [FK_AppUserWish];
GO
IF OBJECT_ID(N'[dbo].[FK_WishAppUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wishes] DROP CONSTRAINT [FK_WishAppUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Things]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Things];
GO
IF OBJECT_ID(N'[dbo].[Households]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Households];
GO
IF OBJECT_ID(N'[dbo].[AppUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppUsers];
GO
IF OBJECT_ID(N'[dbo].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchases];
GO
IF OBJECT_ID(N'[dbo].[Wishes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wishes];
GO
IF OBJECT_ID(N'[dbo].[HouseholdAppUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HouseholdAppUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Things'
CREATE TABLE [dbo].[Things] (
    [ThingId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Needed] bit  NOT NULL,
    [HouseholdHouseholdId] int  NOT NULL,
    [PurchaseThing_Thing_PurchaseId] int  NOT NULL
);
GO

-- Creating table 'Households'
CREATE TABLE [dbo].[Households] (
    [HouseholdId] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AppUsers'
CREATE TABLE [dbo].[AppUsers] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FName] nvarchar(max)  NOT NULL,
    [LName] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [PurchaseId] int IDENTITY(1,1) NOT NULL,
    [MadeOn] datetime  NOT NULL,
    [Paid] float  NOT NULL,
    [AppUser_UserId] int  NOT NULL,
    [Household_HouseholdId] int  NOT NULL
);
GO

-- Creating table 'Wishes'
CREATE TABLE [dbo].[Wishes] (
    [WIshId] int IDENTITY(1,1) NOT NULL,
    [MaxPrice] float  NOT NULL,
    [ExtraPay] float  NOT NULL,
    [MadeOn] datetime  NOT NULL,
    [BoughtOn] datetime  NOT NULL,
    [Status] tinyint  NOT NULL,
    [MadeByUserId] int  NOT NULL,
    [GrantedByUserId] int  NOT NULL
);
GO

-- Creating table 'HouseholdAppUser'
CREATE TABLE [dbo].[HouseholdAppUser] (
    [Households_HouseholdId] int  NOT NULL,
    [AppUsers_UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ThingId] in table 'Things'
ALTER TABLE [dbo].[Things]
ADD CONSTRAINT [PK_Things]
    PRIMARY KEY CLUSTERED ([ThingId] ASC);
GO

-- Creating primary key on [HouseholdId] in table 'Households'
ALTER TABLE [dbo].[Households]
ADD CONSTRAINT [PK_Households]
    PRIMARY KEY CLUSTERED ([HouseholdId] ASC);
GO

-- Creating primary key on [UserId] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [PK_AppUsers]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [PurchaseId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([PurchaseId] ASC);
GO

-- Creating primary key on [WIshId] in table 'Wishes'
ALTER TABLE [dbo].[Wishes]
ADD CONSTRAINT [PK_Wishes]
    PRIMARY KEY CLUSTERED ([WIshId] ASC);
GO

-- Creating primary key on [Households_HouseholdId], [AppUsers_UserId] in table 'HouseholdAppUser'
ALTER TABLE [dbo].[HouseholdAppUser]
ADD CONSTRAINT [PK_HouseholdAppUser]
    PRIMARY KEY CLUSTERED ([Households_HouseholdId], [AppUsers_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HouseholdHouseholdId] in table 'Things'
ALTER TABLE [dbo].[Things]
ADD CONSTRAINT [FK_ThingHousehold]
    FOREIGN KEY ([HouseholdHouseholdId])
    REFERENCES [dbo].[Households]
        ([HouseholdId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ThingHousehold'
CREATE INDEX [IX_FK_ThingHousehold]
ON [dbo].[Things]
    ([HouseholdHouseholdId]);
GO

-- Creating foreign key on [AppUser_UserId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_PurchaseAppUser]
    FOREIGN KEY ([AppUser_UserId])
    REFERENCES [dbo].[AppUsers]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseAppUser'
CREATE INDEX [IX_FK_PurchaseAppUser]
ON [dbo].[Purchases]
    ([AppUser_UserId]);
GO

-- Creating foreign key on [Households_HouseholdId] in table 'HouseholdAppUser'
ALTER TABLE [dbo].[HouseholdAppUser]
ADD CONSTRAINT [FK_HouseholdAppUser_Household]
    FOREIGN KEY ([Households_HouseholdId])
    REFERENCES [dbo].[Households]
        ([HouseholdId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AppUsers_UserId] in table 'HouseholdAppUser'
ALTER TABLE [dbo].[HouseholdAppUser]
ADD CONSTRAINT [FK_HouseholdAppUser_AppUser]
    FOREIGN KEY ([AppUsers_UserId])
    REFERENCES [dbo].[AppUsers]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HouseholdAppUser_AppUser'
CREATE INDEX [IX_FK_HouseholdAppUser_AppUser]
ON [dbo].[HouseholdAppUser]
    ([AppUsers_UserId]);
GO

-- Creating foreign key on [Household_HouseholdId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_PurchaseHousehold]
    FOREIGN KEY ([Household_HouseholdId])
    REFERENCES [dbo].[Households]
        ([HouseholdId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseHousehold'
CREATE INDEX [IX_FK_PurchaseHousehold]
ON [dbo].[Purchases]
    ([Household_HouseholdId]);
GO

-- Creating foreign key on [PurchaseThing_Thing_PurchaseId] in table 'Things'
ALTER TABLE [dbo].[Things]
ADD CONSTRAINT [FK_PurchaseThing]
    FOREIGN KEY ([PurchaseThing_Thing_PurchaseId])
    REFERENCES [dbo].[Purchases]
        ([PurchaseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseThing'
CREATE INDEX [IX_FK_PurchaseThing]
ON [dbo].[Things]
    ([PurchaseThing_Thing_PurchaseId]);
GO

-- Creating foreign key on [MadeByUserId] in table 'Wishes'
ALTER TABLE [dbo].[Wishes]
ADD CONSTRAINT [FK_AppUserWish]
    FOREIGN KEY ([MadeByUserId])
    REFERENCES [dbo].[AppUsers]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppUserWish'
CREATE INDEX [IX_FK_AppUserWish]
ON [dbo].[Wishes]
    ([MadeByUserId]);
GO

-- Creating foreign key on [GrantedByUserId] in table 'Wishes'
ALTER TABLE [dbo].[Wishes]
ADD CONSTRAINT [FK_WishAppUser]
    FOREIGN KEY ([GrantedByUserId])
    REFERENCES [dbo].[AppUsers]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WishAppUser'
CREATE INDEX [IX_FK_WishAppUser]
ON [dbo].[Wishes]
    ([GrantedByUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------