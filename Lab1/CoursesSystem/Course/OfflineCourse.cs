public class OfflineCourse : Course
{
    public string Location { get; set; }
    public string Room { get; set; }
    public string Schedule { get; set; }

    public OfflineCourse(string courseName, string courseCode, int credits, string location, string schedule, string room)   
        : base(courseName, courseCode, credits)
    {
        Location = location;
        Schedule = schedule;
        Room = room;
    }

    public override string GetCourseInfo()
    {
        return $"Offline Course: {CourseName} ({CourseCode}), Credits: {Credits}, Location: {Location}, Schedule: {Schedule}, Room: {Room}";
    }
}