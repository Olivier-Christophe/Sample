CREATE TABLE [dbo].[SampleCategory]
(
	[SampleCategoryId] INT NOT NULL PRIMARY KEY IDENTITY,
	CONSTRAINT FK_Sample FOREIGN KEY (SampleId) REFERENCES [Sample]([SampleId]),
	[SampleId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	CONSTRAINT FK_Category FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId])
)
