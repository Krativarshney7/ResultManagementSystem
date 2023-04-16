using BLL.Service;
using BLL.Validations;
using Common.Base_Classes;

namespace Assignment;

public class AddMenu
{
    StudentService studentService;
    Student student;
    InputValidator validator;

    public AddMenu()
    {
        studentService = new StudentService();
        student = new Student();
        validator = new();
    }

    public void AddStudent()
    {
        try
        {
            bool validSession = false;
            do
            {
                Console.Write("Enter Session (2023 or 2024): ");
                if (int.TryParse(Console.ReadLine(), out int session))
                {
                    if (validator.IsValidSession(session))
                    {
                        student.Session = session;
                        validSession = true;
                    }
                    else
                        Console.WriteLine("Session must be 2023 or 2024.");
                }
                else
                    Console.WriteLine("Invalid input. Session must be a numeric value.");
            } while (!validSession);

            bool validTerm = false;
            do
            {
                Console.Write("Enter Term (1-3): ");
                if (int.TryParse(Console.ReadLine(), out int term))
                {
                    if (validator.IsValidTerm(term))
                    {
                        student.Term = term;
                        validTerm = true;
                    }
                    else
                        Console.WriteLine("Term must be 1, 2 or 3.");
                }
                else
                    Console.WriteLine("Invalid input. Term must be a numeric value.");
            } while (!validTerm);

            bool validAdmissionNo = false;
            do
            {
                Console.Write("Enter Admission Number: ");
                string admissionNoInput = Console.ReadLine();
                if (int.TryParse(admissionNoInput, out int admissionNo))
                {
                    if (admissionNo > 0 && validator.IsAdmissionNoValid(admissionNo, student.Session, student.Term, studentService))
                    {
                        student.AdmissionNo = admissionNo;
                        validAdmissionNo = true;
                    }
                    else
                        Console.WriteLine("Admission number must be unique and greater than 0 for the session and term.");
                }
                else
                    Console.WriteLine("Invalid input. Admission number must be a valid integer.");
            } while (!validAdmissionNo);

            bool validClass = false;
            do
            {
                Console.Write("Enter Class (1-5): ");
                if (int.TryParse(Console.ReadLine(), out int studentClass))
                {
                    if (validator.IsValidClass(studentClass))
                    {
                        student.Class = studentClass;
                        validClass = true;
                    }
                    else
                        Console.WriteLine("Class must be between 1 and 5.");
                }
                else
                    Console.WriteLine("Invalid input. Class must be a numeric value.");
            }
            while (!validClass);

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

            bool validSocialScienceMarks = false;
            do
            {
                Console.Write("Enter Social Science Marks (0-99): ");
                if (int.TryParse(Console.ReadLine(), out int socialScience))
                {
                    if (validator.IsValidMarks(socialScience))
                    {
                        student.SocialScience = socialScience;
                        validSocialScienceMarks = true;
                    }
                    else
                        Console.WriteLine("Invalid input. Social Science marks must be between 0 and 99.");
                }
                else
                    Console.WriteLine("Invalid input. Social Science marks must be a numeric value.");
            } while (!validSocialScienceMarks);

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


            studentService.AddStudent(student);
            Console.WriteLine("Record Saved");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}