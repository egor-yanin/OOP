using System;


public abstract class Course
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();
    public List<Teacher> AssignedTeachers { get; set; } = new List<Teacher>();
    public int CourseID { get; set; }

    public Course(string courseName, string courseCode, int courseID)
    {
        CourseName = courseName;
        CourseCode = courseCode;
        CourseID = courseID;
    }

    public abstract string GetCourseInfo();
    public List<string> GetStudentInfo()
    {
        List<string> studentInfos = new List<string>();
        foreach (var student in EnrolledStudents)
        {
            studentInfos.Add(student.GetInfo());
        }
        return studentInfos;
    }
}