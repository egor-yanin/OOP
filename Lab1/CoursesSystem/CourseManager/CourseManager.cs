using System.Security.Cryptography;

public class CourseManager
{
    public List<Course> Courses { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Student> Students { get; set; }
    private int _nextCourseID = 1;

    public CourseManager()
    {
        Courses = new List<Course>();
        Teachers = new List<Teacher>();
        Students = new List<Student>();
    }

    private Course _findCourseByCode(string courseCode)
    {
        var course = Courses.FirstOrDefault(c => c.CourseCode == courseCode);
        if (course == null)
        {
            throw new Exception("Course not found");
        }
        return course;
    }

    private Course _getCourseByID(int courseID)
    {
        if (courseID < 1 || courseID > Courses.Count)
        {
            throw new Exception("Invalid Course ID");
        }
        return Courses[courseID - 1];
    }

    public void CreateOnlineCourse(string courseName, string courseCode, string platform)
    {
        var course = new OnlineCourse(courseName, courseCode, _nextCourseID, platform);
        _nextCourseID++;
        Courses.Add(course);
    }

    public void CreateOfflineCourse(string courseName, string courseCode, string location, string schedule, string room)
    {
        var course = new OfflineCourse(courseName, courseCode, _nextCourseID, location, schedule, room);
        _nextCourseID++;
        Courses.Add(course);
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