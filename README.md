# StudentsManager

Запросы в SSMS:

CREATE DATABASE StudentGroupDB;

USE StudentGroupDB;

CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Age INT
);

CREATE TABLE Groups (
    GroupId INT PRIMARY KEY IDENTITY(1,1),
    GroupName NVARCHAR(100)
);

CREATE TABLE StudentGroups (
    StudentId INT,
    GroupId INT,
    PRIMARY KEY (StudentId, GroupId),
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId) ON DELETE CASCADE,
    FOREIGN KEY (GroupId) REFERENCES Groups(GroupId) ON DELETE CASCADE
);

Результат:

Группы студента: 
Group A
Группы студента:
Ivan Ivanov
