public class OnlineCourse : Course
{
    public string Platform { get; set; }

    public OnlineCourse(string courseName, string courseCode, int credits, string platform)
        : base(courseName, courseCode, credits)
    {
        Platform = platform;
    }

    public override void DisplayCourseInfo()
    {
        Console.WriteLine($"Online Course: {CourseName} ({CourseCode}), Credits: {Credits}, Platform: {Platform}");
    }
}