public class OnlineCourse : Course
{
    public string Platform { get; set; }

    public OnlineCourse(string courseName, string courseCode, int credits, string platform)
        : base(courseName, courseCode, credits)
    {
        Platform = platform;
    }

    public override string GetCourseInfo()
    {
        return $"Online Course: {CourseName} ({CourseCode}), Credits: {Credits}, Platform: {Platform}";
    }
}