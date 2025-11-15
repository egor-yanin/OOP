public class Student : User
{
    public Student(string name, string email, string idNumber, string department)
    {
        Name = name;
        Email = email;
        IDNumber = idNumber;
        Department = department;
        EnrolledCourses = new List<Course>();
    }

    public override string GetInfo()
    {
        return $"Имя студента: {Name}\nЭл. почта: {Email}\nID: {IDNumber}\nФакультет: {Department}";
    }
}