using Common.Base_Classes;
using Spectre.Console;

namespace Assignment;

public class ShowTable
{
    public void ShowData(List<Student> data)
    {
        var table = new Table();
        table.AddColumn("AdmissionNo");
        table.AddColumn("Session");
        table.AddColumn("Term");
        table.AddColumn("Class");
        table.AddColumn("English");
        table.AddColumn("Math");
        table.AddColumn("Science");
        table.AddColumn("Computer");
        table.AddColumn("SocialScience");
        table.AddColumn("GK");
        table.AddColumn("TotalMarks");
        table.AddColumn("Average");
        table.AddColumn("Grade");

        foreach (Student student in data)
        {
            table.AddRow(
                student.AdmissionNo.ToString(),
                student.Session.ToString(),
                student.Term.ToString(),
                student.Class.ToString(),
                student.English == 0 ? "AB" : student.English.ToString(),
                student.Math == 0 ? "AB" : student.Math.ToString(),
                student.Science == 0 ? "AB" : student.Science.ToString(),
                student.Computer == 0 ? "AB" : student.Computer.ToString(),
                student.SocialScience == 0 ? "AB" : student.SocialScience.ToString(),
                student.GK == 0 ? "AB" : student.GK.ToString(),
                student.TotalMarks.ToString(),
                student.Average.ToString(),
                student.Grade
            );
        }

        table.Title = new TableTitle("[underline yellow]Student Records[/]");
        table.Caption = new TableTitle("[grey]Active Student Records[/]");

        AnsiConsole.Write(table);
    }
}