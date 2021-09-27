CREATE TABLE [Teachers] (
	id integer,
	name varchar,
	hoursperweek integer DEFAULT '0',
  CONSTRAINT [PK_TEACHERS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Courses] (
	id integer,
	subject_id integer NOT NULL,
	course_type varchar NOT NULL,
	members integer NOT NULL,
	classroom varchar,
	comment varchar,
	neptun_ok bit NOT NULL,
	softvware varchar,
	hours integer,
  CONSTRAINT [PK_COURSES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Subjects] (
	id integer NOT NULL,
	name varchar NOT NULL,
	e_hours integer NOT NULL,
	gy_hours integer NOT NULL,
	subject_code varchar NOT NULL,
  CONSTRAINT [PK_SUBJECTS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [courses_teachers] (
	courses_id integer NOT NULL,
	teachers_id integer NOT NULL,
	load integer
)
GO
CREATE TABLE [Szakok] (
	id integer NOT NULL,
	name varchar NOT NULL,
	year integer NOT NULL,
	tagozat varchar NOT NULL,
	szint varchar NOT NULL,
  CONSTRAINT [PK_SZAKOK] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [subject_szakok] (
	subjects_id integer NOT NULL,
	szakok_id integer NOT NULL
)
GO

ALTER TABLE [Courses] WITH CHECK ADD CONSTRAINT [Courses_fk0] FOREIGN KEY ([subject_id]) REFERENCES [Subjects]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Courses] CHECK CONSTRAINT [Courses_fk0]
GO


ALTER TABLE [courses_teachers] WITH CHECK ADD CONSTRAINT [courses_teachers_fk0] FOREIGN KEY ([courses_id]) REFERENCES [Courses]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [courses_teachers] CHECK CONSTRAINT [courses_teachers_fk0]
GO
ALTER TABLE [courses_teachers] WITH CHECK ADD CONSTRAINT [courses_teachers_fk1] FOREIGN KEY ([teachers_id]) REFERENCES [Teachers]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [courses_teachers] CHECK CONSTRAINT [courses_teachers_fk1]
GO


ALTER TABLE [subject_szakok] WITH CHECK ADD CONSTRAINT [subject_szakok_fk0] FOREIGN KEY ([subjects_id]) REFERENCES [Subjects]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [subject_szakok] CHECK CONSTRAINT [subject_szakok_fk0]
GO
ALTER TABLE [subject_szakok] WITH CHECK ADD CONSTRAINT [subject_szakok_fk1] FOREIGN KEY ([szakok_id]) REFERENCES [Szakok]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [subject_szakok] CHECK CONSTRAINT [subject_szakok_fk1]
GO
