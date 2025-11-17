using System;


public abstract class Course
{
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();
    public List<Teacher> AssignedTeachers { get; set; } = new List<Teacher>();

    public Course(string courseName, string courseCode)
    {
        CourseName = courseName;
        CourseCode = courseCode;
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