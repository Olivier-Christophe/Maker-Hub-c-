CREATE TABLE [dbo].[Sample] (
    [SampleId]         INT            IDENTITY (1, 1) NOT NULL,
    [Auteur]           NVARCHAR (50)  NULL,
    [Titre]            NVARCHAR (50)  NOT NULL,
    [Description]      NVARCHAR (250) NULL,
    [Format]           NVARCHAR (50)  NULL,
    [URL]              NVARCHAR (250) NULL,
    [IsTelechargeable] BIT            NULL,
    [Photo]            NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([SampleId] ASC)
);


