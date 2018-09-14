
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/01/2018 11:49:43
-- Generated from EDMX file: D:\Myvs\20180621EF\MVC_EF\ModelFirst\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [T3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookType'
CREATE TABLE [dbo].[BookType] (
    [TypeId] int IDENTITY(1,1) NOT NULL,
    [TypeTitle] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'BookInfo'
CREATE TABLE [dbo].[BookInfo] (
    [BookId] int IDENTITY(1,1) NOT NULL,
    [BookTitle] nvarchar(50)  NOT NULL,
    [BookTypeTypeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TypeId] in table 'BookType'
ALTER TABLE [dbo].[BookType]
ADD CONSTRAINT [PK_BookType]
    PRIMARY KEY CLUSTERED ([TypeId] ASC);
GO

-- Creating primary key on [BookId] in table 'BookInfo'
ALTER TABLE [dbo].[BookInfo]
ADD CONSTRAINT [PK_BookInfo]
    PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BookTypeTypeId] in table 'BookInfo'
ALTER TABLE [dbo].[BookInfo]
ADD CONSTRAINT [FK_BookTypeBookInfo]
    FOREIGN KEY ([BookTypeTypeId])
    REFERENCES [dbo].[BookType]
        ([TypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookTypeBookInfo'
CREATE INDEX [IX_FK_BookTypeBookInfo]
ON [dbo].[BookInfo]
    ([BookTypeTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------