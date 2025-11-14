using System;


public abstract class Course
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public int Credits { get; set; }

    public Course(string courseName, string courseCode, int credits)
    {
        CourseName = courseName;
        CourseCode = courseCode;
        Credits = credits;
    }

    public abstract void DisplayCourseInfo();
}