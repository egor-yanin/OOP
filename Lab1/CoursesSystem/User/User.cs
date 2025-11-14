public abstract class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string IDNumber { get; set; }
    public string Department { get; set; }

    public List<Course> EnrolledCourses { get; set; }

    public void AddCourse(Course course)
    {
        EnrolledCourses.Add(course);
    }
}