if exists(select 1 from master.dbo.sysdatabases where name = 'LinqToSql') drop database LinqToSql
GO
CREATE DATABASE LinqToSql
GO


CREATE TABLE LinqToSql.dbo.Department (	
		
    DepartmentId INT PRIMARY KEY,
    Name VARCHAR(30) NOT NULL,
);    
GO

CREATE TABLE LinqToSql.dbo.Employee (	
		
    EmployeeId INT PRIMARY KEY,
    Name VARCHAR(30) NOT NULL,
	Email VARCHAR(60) NOT NULL,
	ContactNo VARCHAR(12) NOT NULL,
	DepartmentId INT NOT NULL,
	Adress VARCHAR(40) NOT NULL,
	DepartmentId int FOREIGN KEY REFERENCES LinqToSql.dbo.Department(DepartmentId),

);  