using BLL.Service;

namespace BLL.Validations;

public class InputValidator
{
    public bool IsValidSession(int session)
    {
        return session == 2023 || session == 2024;
    }

    public bool IsValidTerm(int term)
    {
        return term >= 1 && term <= 3;
    }

    public bool IsAdmissionNoValid(int admissionNo, int session, int term, StudentService studentService)
    {
        return admissionNo > 0 && studentService.IsAdmissionNoUnique(admissionNo, session, term);
    }

    public bool IsValidClass(int studentClass)
    {
        return studentClass >= 1 && studentClass <= 5;
    }

    public bool IsValidMarks(int marks)
    {
        return marks >= 0 && marks <= 99;
    }
}