public class Teacher : User
{
    public Teacher(string name, string email, string idNumber, string department)
    {
        Name = name;
        Email = email;
        IDNumber = idNumber;
        Department = department;
        EnrolledCourses = new List<Course>();
    }

    public override string GetInfo()
    {
        return $"Имя учителя";
    }
}