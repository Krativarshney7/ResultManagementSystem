using BLL.Service;
using BLL.Validations;
using Common.Base_Classes;

namespace Assignment;

public class UpdateMenu
{
    StudentService studentService;
    Student student;
    InputValidator validator;

    public UpdateMenu()
    {
        studentService = new();
        student = new();
        validator = new();
    }
    public void UpdateStudent()
    {
        try
        {
            bool validAdmissionNo = false;
            int admissionNo;
            do
            {
                Console.Write("Enter Admission Number: ");
                string admissionNoInput = Console.ReadLine();
                if (int.TryParse(admissionNoInput, out admissionNo))
                {
                    if (admissionNo > 0) 
                        validAdmissionNo = true;
                    else
                        Console.WriteLine("Admission number must be greater than 0.");
                }
                else
                    Console.WriteLine("Invalid input. Admission number must be a valid integer.");
            } while (!validAdmissionNo);

            student = studentService.GetAllStudents().FirstOrDefault(x => x.AdmissionNo == admissionNo);

            if (student != null && student.IsDeleted == 0)
            {
                student.AdmissionNo = admissionNo;

                bool validEnglishMarks = false;
                do
                {
                    Console.Write("Enter English Marks (0-99): ");
                    if (int.TryParse(Console.ReadLine(), out int english))
                    {
                        if (validator.IsValidMarks(english))
                        {
                            student.English = english;
                            validEnglishMarks = true;
                        }
                        else
                            Console.WriteLine("Invalid input. English marks must be between 0 and 99.");
                    }
                    else
                        Console.WriteLine("Invalid input. English marks must be a numeric value.");
                } while (!validEnglishMarks);

                bool validMathMarks = false;
                do
                {
                    Console.Write("Enter Math Marks (0-99): ");
                    if (int.TryParse(Console.ReadLine(), out int math))
                    {
                        if (validator.IsValidMarks(math))
                        {
                            student.Math = math;
                            validMathMarks = true;
                        }
                        else
                            Console.WriteLine("Invalid input. Math marks must be between 0 and 99.");
                    }
                    else
                        Console.WriteLine("Invalid input. Math marks must be a numeric value.");
                } while (!validMathMarks);

                bool validScienceMarks = false;
                do
                {
                    Console.Write("Enter Science Marks (0-99): ");
                    if (int.TryParse(Console.ReadLine(), out int science))
                    {
                        if (validator.IsValidMarks(science))
                        {
                            student.Science = science;
                            validScienceMarks = true;
                        }
                        else
                            Console.WriteLine("Invalid input. Science marks must be between 0 and 99.");
                    }
                    else
                        Console.WriteLine("Invalid input. Science marks must be a numeric value.");
                } while (!validScienceMarks);

                bool validComputerMarks = false;
                do
                {
                    Console.Write("Enter Computer Marks (0-99): ");
                    if (int.TryParse(Console.ReadLine(), out int computer))
                    {
                        if (validator.IsValidMarks(computer))
                        {
                            student.Computer = computer;
                            validComputerMarks = true;
                        }
                        else
                            Console.WriteLine("Invalid input. Computer marks must be between 0 and 99.");
                    }
                    else
                        Console.WriteLine("Invalid input. Computer marks must be a numeric value.");
                } while (!validComputerMarks);

                bool validsocialScienceMarks = false;
                do
                {
                    Console.Write("Enter Social Science Marks (0-99): ");
                    if (int.TryParse(Console.ReadLine(), out int socialScience))
                    {
                        if (validator.IsValidMarks(socialScience))
                        {
                            student.SocialScience = socialScience;
                            validsocialScienceMarks = true;
                        }
                        else
                            Console.WriteLine("Invalid input. Social Science marks must be between 0 and 99.");
                    }
                    else
                        Console.WriteLine("Invalid input. Social Science marks must be a numeric value.");
                } while (!validsocialScienceMarks);

                bool validGKMarks = false;
                do
                {
                    Console.Write("Enter General Knowledge Marks (0-99): ");
                    if (int.TryParse(Console.ReadLine(), out int gk))
                    {
                        if (validator.IsValidMarks(gk))
                        {
                            student.GK = gk;
                            validGKMarks = true;
                        }
                        else
                            Console.WriteLine("Invalid input. General Knowledge marks must be between 0 and 99.");
                    }
                    else
                        Console.WriteLine("Invalid input. General Knowledge marks must be a numeric value.");
                } while (!validGKMarks);

                if (studentService.UpdateStudent(student.AdmissionNo, student))
                    Console.WriteLine("Record Updated!");
            }
            else
                Console.WriteLine("Incorrect Admission No. Please try again.");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
