public class Student : User
{
    public string Group { get; set; }
    public string Year { get; set; }

    public Student(string name, string email, int idNumber, string department, string group, string year)
        : base(name, email, idNumber, department)
    {
        Group = group;
        Year = year;
    }

    public override string GetInfo()
    {
        return $"Имя студента: {Name}\nЭл. почта: {Email}\nID: {IDNumber}\nФакультет: {Department}\nГруппа: {Group}\nГод обучения: {Year}";
    }
}