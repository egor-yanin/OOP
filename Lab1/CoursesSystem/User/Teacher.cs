public class Teacher : User
{
    public string Qualification { get; set; }

    public Teacher(string name, string email, int idNumber, string department, string qualification)
        : base(name, email, idNumber, department)
    {
        Qualification = qualification;
    }

    public override string GetInfo()
    {
        return $"Имя учителя{Name}\nЭл. почта: {Email}\nID: {IDNumber}\nФакультет: {Department}\nКвалификация: {Qualification}";
    }
}