CREATE TABLE Semester (
	id integer NOT NULL,
	date varchar(100) NOT NULL,
  CONSTRAINT [PK_SEMESTER] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)

ALTER TABLE Subjects 
ADD semester_id int NOT NULL

ALTER TABLE [Subjects] WITH CHECK ADD CONSTRAINT [Subjects_fk0] FOREIGN KEY ([semester_id]) REFERENCES [Semester]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Subjects] CHECK CONSTRAINT [Subjects_fk0]


