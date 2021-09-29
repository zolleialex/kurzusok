exec sp_rename 'Szakok', 'Programmes'
exec sp_rename 'subject_szakok', 'subject_programmes'
exec sp_rename 'Programmes.tagozat', 'training' , 'COLUMN';
exec sp_rename 'Programmes.szint', 'levels' , 'COLUMN';
alter table Courses ADD course_code varchar(100) NOT NULL

alter table dbo.Courses alter column course_type varchar(100) 
alter table dbo.Courses alter column classroom varchar(100) 
alter table dbo.Courses alter column comment varchar(100) 
alter table dbo.Courses alter column softvware varchar(100) 
alter table dbo.Courses alter column course_code varchar(100) NOT NULL
alter table dbo.Subjects alter column name varchar(100) NOT NULL
alter table dbo.Subjects alter column subject_code varchar(100) NOT NULL
alter table dbo.Subjects alter column e_hours int NULL
alter table dbo.Subjects alter column gy_hours int NULL

alter table dbo.Programmes alter column name varchar(100) NOT NULL
alter table dbo.Programmes alter column training varchar(100) NOT NULL
alter table dbo.Programmes alter column levels varchar(100) NOT NULL

alter table dbo.Teachers alter column name varchar(100) NOT NULL

