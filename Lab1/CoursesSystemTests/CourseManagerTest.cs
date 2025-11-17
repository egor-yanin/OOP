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

}
