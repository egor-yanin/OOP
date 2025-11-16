public abstract class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string IDNumber { get; set; }
    public string Department { get; set; }

    public List<Course> EnrolledCourses { get; set; }

    public User(string name, string email, string idNumber, string department)
    {
        Name = name;
        Email = email;
        IDNumber = idNumber;
        Department = department;
        EnrolledCourses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        EnrolledCourses.Add(course);
    }

    public abstract string GetInfo();
}