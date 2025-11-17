public class OfflineCourse : Course
{
    public string Location { get; set; }
    public string Room { get; set; }
    public string Schedule { get; set; }

    public OfflineCourse(string courseName, string courseCode, int courseID, string location, string schedule, string room)
        : base(courseName, courseCode, courseID)
    {
        Location = location;
        Schedule = schedule;
        Room = room;
    }

    public override string GetCourseInfo()
    {
        return $"Offline Course: {CourseName} ({CourseCode}), Location: {Location}, Schedule: {Schedule}, Room: {Room}";
    }
}