
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/22/2017 18:57:53
-- Generated from EDMX file: C:\Projetos\vegetais-blog\Vegetais.Blog.Web\BlogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VegetaisBlog];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PostSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostSet];
GO
IF OBJECT_ID(N'[dbo].[AssociadoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssociadoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ArtigoSet'
CREATE TABLE [dbo].[ArtigoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Imagem] nvarchar(max)  NULL,
    [Video] nvarchar(max)  NULL,
    [Conteudo] nvarchar(max)  NOT NULL,
    [Permalink] nvarchar(max)  NOT NULL,
    [SoParaAssinantes] bit  NOT NULL
);
GO

-- Creating table 'AssociadoSet'
CREATE TABLE [dbo].[AssociadoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [IP] nvarchar(max)  NOT NULL,
    [HoraCadastro] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ArtigoSet'
ALTER TABLE [dbo].[ArtigoSet]
ADD CONSTRAINT [PK_ArtigoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssociadoSet'
ALTER TABLE [dbo].[AssociadoSet]
ADD CONSTRAINT [PK_AssociadoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------