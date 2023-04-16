namespace Common.Base_Classes;

public class Student
{
    public int AdmissionNo { get; set; }
    public int Session { get; set; }
    public int Term { get; set; }
    public int Class { get; set; }
    public int English { get; set; }
    public int Math { get; set; }
    public int Science { get; set; }
    public int Computer { get; set; }
    public int SocialScience { get; set; }
    public int GK { get; set; }
    public int TotalMarks { get; set; }
    public double Average { get; set; }
    public string Grade { get; set; } = String.Empty;
    public int IsDeleted { get; set; } = 0;
}