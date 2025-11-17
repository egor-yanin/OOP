using CoursesSystem.CourseManager; // Add this if CourseManager is in the CoursesSystem namespace

public class CourseManagerTest
{
    [Fact]
    public void CreateOnlineCourse_AddsCourseToCoursesList()
    {
        // Arrange
        var manager = new CourseManager();
        string courseName = "C# Basics";
        string courseCode = "CS101";
        string platform = "Zoom";

        // Act
        manager.CreateOnlineCourse(courseName, courseCode, platform);

        // Assert
        Assert.Single(manager.Courses);
        var course = manager.Courses.First();
        Assert.IsType<OnlineCourse>(course);
        Assert.Equal(courseName, course.CourseName);
        Assert.Equal(courseCode, course.CourseCode);
        Assert.Equal(platform, ((OnlineCourse)course).Platform);
    }

    [Fact]
    public void CreateOnlineCourse_AssignsIncrementalCourseID()
    {
        // Arrange
        var manager = new CourseManager();

        // Act
        manager.CreateOnlineCourse("Course1", "C1", "Platform1");
        manager.CreateOnlineCourse("Course2", "C2", "Platform2");

        // Assert
        Assert.Equal(2, manager.Courses.Count);
        Assert.Equal(1, manager.Courses[0].CourseID);
        Assert.Equal(2, manager.Courses[1].CourseID);
    }

    [Fact]
    public void CreateOfflineCourse_AddsCourseToCoursesList()
    {
        // Arrange
        var manager = new CourseManager();
        string courseName = "Math 101";
        string courseCode = "MATH101";
        string location = "Building A";
        string schedule = "Mon-Wed 10:00-12:00";
        string room = "101";

        // Act
        manager.CreateOfflineCourse(courseName, courseCode, location, schedule, room);

        // Assert
        Assert.Single(manager.Courses);
        var course = manager.Courses.First();
        Assert.IsType<OfflineCourse>(course);
        Assert.Equal(courseName, course.CourseName);
        Assert.Equal(courseCode, course.CourseCode);
        Assert.Equal(location, ((OfflineCourse)course).Location);
        Assert.Equal(schedule, ((OfflineCourse)course).Schedule);
        Assert.Equal(room, ((OfflineCourse)course).Room);
    }

    [Fact]
    public void CreateOfflineCourse_AssignsIncrementalCourseID()
    {
        // Arrange
        var manager = new CourseManager();

        // Act
        manager.CreateOfflineCourse("Course1", "C1", "Loc1", "Sched1", "Room1");
        manager.CreateOfflineCourse("Course2", "C2", "Loc2", "Sched2", "Room2");

        // Assert
        Assert.Equal(2, manager.Courses.Count);
        Assert.Equal(1, manager.Courses[0].CourseID);
        Assert.Equal(2, manager.Courses[1].CourseID);
    }

    [Fact]
    public void AssignUserToCourse_AssignsTeacherAndCourseCorrectly()
    {
        // Arrange
        var manager = new CourseManager();
        manager.RegisterTeacher("Alice", "alice@example.com", "Math", "PhD");
        manager.CreateOnlineCourse("Algebra", "ALG101", "Teams");
        int teacherID = manager.Teachers[0].IDNumber;
        int courseID = manager.Courses[0].CourseID;

        // Act
        manager.AssignUserToCourse(teacherID, courseID);

        // Assert
        var course = manager.Courses[0];
        var teacher = manager.Teachers[0];
        Assert.Contains(teacher, course.AssignedTeachers);
        Assert.Contains(course, teacher.EnrolledCourses);
    }

    [Fact]
    public void AssignUserToCourse_AssignsStudentAndCourseCorrectly()
    {
        // Arrange
        var manager = new CourseManager();
        manager.RegisterStudent("Bob", "bob@example.com", "Math", "G1", "1");
        manager.CreateOnlineCourse("Algebra", "ALG101", "Teams");
        int studentID = manager.Students[0].IDNumber;
        int courseID = manager.Courses[0].CourseID;

        // Act
        manager.AssignUserToCourse(studentID, courseID);

        // Assert
        var course = manager.Courses[0];
        var student = manager.Students[0];
        Assert.Contains(student, course.EnrolledStudents);
        Assert.Contains(course, student.EnrolledCourses);
    }

    [Fact]
    public void AssignUserToCourse_ThrowsException_WhenUserDoesNotExist()
    {
        // Arrange
        var manager = new CourseManager();
        manager.CreateOnlineCourse("Algebra", "ALG101", "Teams");
        int invalidUserID = 999;
        int courseID = manager.Courses[0].CourseID;

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => manager.AssignUserToCourse(invalidUserID, courseID));
        Assert.Contains("Error assigning user to course", ex.Message);
    }

    [Fact]
    public void AssignUserToCourse_ThrowsException_WhenCourseDoesNotExist()
    {
        // Arrange
        var manager = new CourseManager();
        manager.RegisterTeacher("Alice", "alice@example.com", "Math", "PhD");
        int teacherID = manager.Teachers[0].IDNumber;
        int invalidCourseID = 999;

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => manager.AssignUserToCourse(teacherID, invalidCourseID));
        Assert.Contains("Error assigning user to course", ex.Message);
    }
}
