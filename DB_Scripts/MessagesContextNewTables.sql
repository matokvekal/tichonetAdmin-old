﻿CREATE TABLE [dbo].[tblRecepientFilterTableName] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,

	[Name]			NVARCHAR (MAX)	NOT NULL,
	[ReferncedTableName]			NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[tblRecepientFilter] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
	[tblRecepientFilterTableNameId]	INT		NOT NULL,

	[Name]			NVARCHAR (150)	NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[tblFilter] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
    [tblRecepientFilterId]			INT				NOT NULL,

	[Key]			NVARCHAR (MAX)	NOT NULL,
	[Value]			NVARCHAR (MAX)	NOT NULL,
	[Operator]		NVARCHAR (10)	NOT NULL,
    [Type]          NVARCHAR (100) NOT NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[tblWildcard] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
    [tblRecepientFilterId]			INT				NOT NULL,

	[Name]			NVARCHAR (150)	NOT NULL,
	[Code]			NVARCHAR (150)	NOT NULL,
	[Key]			NVARCHAR (MAX)	NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[tblTemplate] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
    [tblRecepientFilterId]			INT				NOT NULL,

	[Name]			NVARCHAR (150)	NOT NULL,

	[IsSms]			BIT				NOT NULL, 
	[MsgHeader]		NVARCHAR (500)	NULL,
	[MsgBody]		NVARCHAR (MAX)	NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);