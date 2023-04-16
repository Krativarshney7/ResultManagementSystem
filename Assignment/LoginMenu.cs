using BLL.Service;
using Common.Base_Classes;

namespace Assignment;

public class LoginMenu
{
    AddMenu addMenu;
    UpdateMenu updateMenu;
    DeleteMenu deleteMenu;
    SearchMenu searchMenu;
    StudentService studentService;
    LoginUser loginUser;
    ShowTable showTable;

    public LoginMenu()
    {
        addMenu = new();
        updateMenu = new();
        deleteMenu = new();
        searchMenu = new();
        studentService = new();
        loginUser = new();
        showTable = new();
    }
    public void ShowMenu()
    {

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Result Management System");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. List");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Back");
            Console.Write("Enter choice: ");

            string inputVal = Console.ReadLine();
            if (inputVal.Length == 0)
                Console.WriteLine("You never skip the entry");
            else if (int.TryParse(inputVal, out int choiceInt))
            {
                switch (choiceInt)
                {
                    case 1:
                        addMenu.AddStudent();
                        break;
                    case 2:
                        updateMenu.UpdateStudent();
                        break;
                    case 3:
                        List<Student> data = studentService.GetAllStudents();
                        if (data != null && data.Count > 0)
                        {
                            var filteredData = data.Where(s => s.IsDeleted == 0).ToList();
                            if (filteredData != null && filteredData.Count > 0) 
                                showTable.ShowData(filteredData);
                            else
                                Console.WriteLine("No record found");
                        }
                        else
                            Console.WriteLine("No record found!");
                        break;
                    case 4:
                        deleteMenu.DeleteStudent();
                        break;
                    case 5:
                        searchMenu.SearchStudent();
                        break;
                    case 6:
                        loginUser.ViewPage();
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
}