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
}