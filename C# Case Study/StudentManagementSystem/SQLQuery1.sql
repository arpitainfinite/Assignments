use SMSProject;
Select * from dbo.Students;
Select * from dbo.Courses;
Select * from dbo.Enrollments;
CREATE TABLE Enrollments (
    StudentId INT,
    CourseId INT,
    FOREIGN KEY (StudentId) REFERENCES dbo.Students(Id),
    FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId)
);

