using BLL.Service;
using Common.Base_Classes;

namespace Assignment;

public class DeleteMenu
{
    StudentService studentService;
    Student student;

    public DeleteMenu()
    {
        studentService = new();
        student = new();
    }

    public void DeleteStudent()
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
                Console.Write("Are you sure you want to delete your Account?: (yes/no) ");
                string confirmation = Console.ReadLine().ToLower();

                while (confirmation != "yes" && confirmation != "no")
                {
                    Console.Write("Invalid input. Please enter 'yes' or 'no': ");
                    confirmation = Console.ReadLine().ToLower();
                }

                if (confirmation == "yes" && studentService.DeleteStudent(admissionNo)) 
                    Console.WriteLine("Record Deleted!");
            }
            else
                Console.WriteLine("Incorrect Admission No. Please try again.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
