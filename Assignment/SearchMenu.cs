using BLL.Service;
using BLL.Validations;
using Common.Base_Classes;

namespace Assignment;

public class SearchMenu
{
    StudentService studentService;
    ShowTable showTable;
    InputValidator validator;

    public SearchMenu()
    {
        studentService = new();
        showTable = new();
        validator = new();
    }

    public void SearchStudent()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Session and term");
            Console.WriteLine("2. Class");
            Console.WriteLine("3. AdmissionNo Range(From AdmissionNoFrom -AdmissionNoTo)");
            Console.WriteLine("4. Back");
            Console.Write("Enter choice: ");

            string inputVal = Console.ReadLine();
            if (inputVal.Length == 0)
                Console.WriteLine("You never skip the entry");
            else if (int.TryParse(inputVal, out int choiceInt))
            {
                switch (choiceInt)
                {
                    case 1:
                        SearchingSession();
                        break;
                    case 2:
                        SearchingClass();
                        break;
                    case 3:
                        SearchingRange();
                        break;
                    case 4:
                        LoginMenu loginMenu = new();
                        loginMenu.ShowMenu();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter valid choice!");
                        break;
                }
            }
            else
                Console.WriteLine("Only Digits are allowed");
            Console.ReadKey();
        }
    }

    public void SearchingSession()
    {
        bool validSession = false;
        int session;
        do
        {
            Console.Write("Enter Session (2023 or 2024): ");
            if (int.TryParse(Console.ReadLine(), out session))
            {
                if (validator.IsValidSession(session)) 
                    validSession = true;
                else
                    Console.WriteLine("Session must be 2023 or 2024.");
            }
            else
                Console.WriteLine("Invalid input. Session must be a numeric value.");
        } while (!validSession);

        bool validTerm = false;
        int term;
        do
        {
            Console.Write("Enter Term (1-3): ");
            if (int.TryParse(Console.ReadLine(), out term))
            {
                if (validator.IsValidTerm(term))
                    validTerm = true;
                else
                    Console.WriteLine("Term must be 1, 2 or 3.");
            }
            else
                Console.WriteLine("Invalid input. Term must be a numeric value.");
        } while (!validTerm);

        List<Student> data = studentService.GetAllStudents();
        if (data?.Count > 0)
        {
            List<Student> filteredData = studentService.FilterData(data, session, term);
            if (filteredData?.Count > 0)
            {
                filteredData = studentService.DescendingFilterData(filteredData);
                showTable.ShowData(filteredData);
            }
            else
                Console.WriteLine("No record found for the given session and term.");
        }
        else
            Console.WriteLine("No record found!");
    }

    public void SearchingClass()
    {
        bool validClass = false;
        int studentClass;
        do
        {
            Console.Write("Enter Class (1-5): ");
            if (int.TryParse(Console.ReadLine(), out studentClass))
            {
                if (validator.IsValidClass(studentClass))
                    validClass = true;
                else
                    Console.WriteLine("Class must be between 1 and 5.");
            }
            else
                Console.WriteLine("Invalid input. Class must be a numeric value.");
        }
        while (!validClass);

        List<Student> students = studentService.GetAllStudents();
        if (students?.Count > 0)
        {
            Student filteredData = studentService.FilterStudentData(students, studentClass);
            if (filteredData != null)
            {
                List<Student> Data = new()
                {
                    filteredData
                };
                showTable.ShowData(Data);
            }
            else
                Console.WriteLine("No record found for the given class.");
        }
        else
            Console.WriteLine("No record found!");
    }

    public void SearchingRange()
    {
        bool validAdmissionNoFrom = false;
        int admissionNoFrom;
        do
        {
            Console.Write("Enter Admission No (From): ");
            if (int.TryParse(Console.ReadLine(), out admissionNoFrom))
                validAdmissionNoFrom = true;
            else
                Console.WriteLine("Invalid input. Admission No (From) must be a numeric value.");
        } while (!validAdmissionNoFrom);

        bool validAdmissionNoTo = false;
        int admissionNoTo;
        do
        {
            Console.Write("Enter Admission No (To): ");
            if (int.TryParse(Console.ReadLine(), out admissionNoTo))
                validAdmissionNoTo = true;
            else
                Console.WriteLine("Invalid input. Admission No (To) must be a numeric value.");
        } while (!validAdmissionNoTo);

        List<Student> data = studentService.GetAllStudents();
        if (data?.Count > 0)
        {
            List<Student> filteredData = studentService.FilterRangeData(data, admissionNoFrom, admissionNoTo);
            if (filteredData?.Count > 0)
            {
                filteredData = studentService.FilterAndSortData(filteredData);
                showTable.ShowData(filteredData);
            }
            else
                Console.WriteLine("No record found for the given admission number range.");
        }
        else
            Console.WriteLine("No record found!");
    }
}