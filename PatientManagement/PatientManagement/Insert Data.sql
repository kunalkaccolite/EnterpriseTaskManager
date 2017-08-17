USE [Hospital]
GO

INSERT INTO [dbo].[Doctor]
           ([DoctorId]
           ,[DoctorName]
           ,[PhoneNumber])
     VALUES
           ('12345'
           ,'Venu'
           ,9872345612),
		     ('12346'
           ,'Girish'
           ,9812345612),
		     ('12347'
           ,'Vidya'
           ,9235234312),
		     ('12348'
           ,'rashmi'
           ,981234312),
		     ('12349'
           ,'Shrishail'
           ,9873214561),
		     ('12350'
           ,'Rasmika'
           ,9123456123),
		     ('12351'
           ,'Shradha'
           ,9875643290)
GO



INSERT INTO [dbo].[Procedure]
           ([ProcedureCode]
           ,[ProcedureDescription]
           ,[ProcedureRate])
     VALUES
           (96150
           ,'Health and behavior assesment'
           ,3000),
		     (97802
           ,'Medical nutrition therapy'
           ,1880),
		     (9210
           ,'OPD new patient'
           ,300),
		     (99212
           ,'OPD established patient'
           ,200),
		     (99251
           ,'Inpatient consultation'
           ,1982)

