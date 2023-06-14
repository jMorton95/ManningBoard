USE [ManningBoardPoc]
GO

INSERT INTO [dbo].[Operator]
           ([ClockCardNumber],[OperatorName])
     VALUES
           ('425212','Josh Marvin'),
		   ('346234', 'Ben Handerson'),
		   ('124322', 'Scott Levinson'),
		   ('234234', 'Janet Parkinson'),
		   ('845433', 'Ian Hazzikostas'),
		   ('235133', 'Canary Aislington'),
		   ('383253', 'John Mathers'),
		   ('889446', 'Geraldine Scott'),
		   ('298765', 'Caroline Alberta'),
		   ( '167345', 'Robert California')

GO

INSERT INTO dbo.[Zone] ([ZoneName])

VALUES ('Zone 1'),
	   ('Zone 2'),
	   ('Zone 3')
GO

INSERT INTO dbo.[Station] ([StationName], [ZoneID])
VALUES ('Z1_Op1', '1'),('Z1_Op2', '1'),('Z1_Op3', '1'),('Z1_Op4', '1'),('Z1_Op5', '1'),('Z1_Op6', '1'),('Z1_Op7', '1'),('Z1_Op8', '1'),('Z1_Op9', '1'),('Z1_Op10', '1'),
	('Z2_Op1', '2'),('Z2_Op2', '2'),('Z2_Op3', '2'),('Z2_Op4', '2'),('Z2_Op5', '2'),('Z2_Op6', '2'),('Z2_Op7', '2'),('Z2_Op8', '2'),('Z2_Op9', '2'),('Z2_Op10', '2'),
	('Z3_Op1', '3'),('Z3_Op2', '3'),('Z3_Op3', '3'),('Z3_Op4', '3'),('Z3_Op5', '3'),('Z3_Op6', '3'),('Z3_Op7', '3'),('Z3_Op8', '3'),('Z3_Op9', '3'),('Z3_Op10', '3')

GO

INSERT INTO dbo.[TrainingRequirementsType] ([TrainingType])
VALUES ('Prerequisite'),('StandardOperatingProcedure'),('TrainerCapable')

