public class OnlineCourse : Course
{
    public string Platform { get; set; }

    public OnlineCourse(string courseName, string courseCode, int courseID, string platform)
        : base(courseName, courseCode, courseID)
    {
        Platform = platform;
    }

    public override string GetCourseInfo()
    {
        return $"Online Course: {CourseName} ({CourseCode}), Platform: {Platform}";
    }
}