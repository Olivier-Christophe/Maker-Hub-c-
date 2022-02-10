CREATE TABLE [dbo].[SampleCategory] (
    [SampleCategoryId] INT IDENTITY (1, 1) NOT NULL,
    [SampleId]         INT NOT NULL,
    [CategoryId]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([SampleCategoryId] ASC),
    CONSTRAINT [FK_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sample] FOREIGN KEY ([SampleId]) REFERENCES [dbo].[Sample] ([SampleId]) ON DELETE CASCADE
);


