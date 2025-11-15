public class CourseManager
{
    public List<Course> Courses { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Student> Students { get; set; }

    public void CreateOnlineCourse(string courseName, string courseCode, int credits)
    {
        // Implementation for creating a course
    }

    public void CreateOfflineCourse(string courseName, string courseCode, int credits)
    {
        // Implementation for creating a course
    }

    public void AssignTeacherToCourse(string teacherID, string courseCode)
    {
        // Implementation for assigning a teacher to a course
    }

    public void EnrollStudentInCourse(string studentID, string courseCode)
    {
        // Implementation for enrolling a student in a course
    }

    public void DeleteCourse(string courseCode)
    {
        // Implementation for deleting a course
    }
}