using Common.Base_Classes;
using DAL.Repository;
using System.Configuration;

namespace BLL.Service;

public class StudentService
{
    Repository<Student> studentRepository;

    public StudentService()
    {
        studentRepository = new(ConfigurationManager.AppSettings["StudentPath"]);
    }

    public List<Student> GetAllStudents()
    {
        return studentRepository.GetAll();
    }

    public void AddStudent(Student student)
    {
        List<Student> students = GetAllStudents();
        student.TotalMarks = student.English + student.Math + student.Science + student.Computer + student.SocialScience + student.GK;
        student.Average = Math.Round(student.TotalMarks / 6.0, 2);

        if (student.Average < 35)
            student.Grade = "F";
        else if (student.Average >= 35 && student.Average <= 60)
            student.Grade = "P";
        else if (student.Average >= 61 && student.Average <= 75)
            student.Grade = "S";
        else
            student.Grade = "A";
        students.Add(student);
        studentRepository.SaveAll(students);
    }

    public bool UpdateStudent(int admissionNo, Student student)
    {
        List<Student> students = GetAllStudents();
        bool isUpdated = false;
        if (students.Count > 1)
        {
            Student studentToUpdate = students.Where(s => s.AdmissionNo == admissionNo && s.IsDeleted == 0)
                          .OrderByDescending(s => s.Session)
                          .ThenByDescending(s => s.Term)
                          .FirstOrDefault();

            if (studentToUpdate != null)
            {
                UpdateStudentData(studentToUpdate, student);
                isUpdated = true;
            }
        }
        else
        {
            Student studentToUpdate = students.FirstOrDefault(s => s.AdmissionNo == admissionNo && s.IsDeleted == 0);

            if (studentToUpdate != null)
            {
                UpdateStudentData(studentToUpdate, student);
                isUpdated = true;
            }
        }

        if (isUpdated)
        {
            studentRepository.SaveAll(students);
            return true;
        }
        return false;
    }

    private void UpdateStudentData(Student studentToUpdate, Student student)
    {
        studentToUpdate.English = student.English;
        studentToUpdate.Math = student.Math;
        studentToUpdate.Science = student.Science;
        studentToUpdate.Computer = student.Computer;
        studentToUpdate.SocialScience = student.SocialScience;
        studentToUpdate.GK = student.GK;
        studentToUpdate.TotalMarks = student.English + student.Math + student.Science + student.Computer + student.SocialScience + student.GK;
        studentToUpdate.Average = Math.Round(student.TotalMarks / 6.0, 2);

        if (studentToUpdate.Average < 35)
            studentToUpdate.Grade = "F";
        else if (studentToUpdate.Average <= 60)
            studentToUpdate.Grade = "P";
        else if (studentToUpdate.Average <= 75)
            studentToUpdate.Grade = "S";
        else
            studentToUpdate.Grade = "A";
    }

    public bool DeleteStudent(int admissionNo)
    {
        List<Student> students = GetAllStudents();
        if (students.Count > 1)
        {

            Student studentToDelete = students.Where(s => s.AdmissionNo == admissionNo && s.IsDeleted == 0)
                           .OrderByDescending(s => s.Session)
                           .ThenByDescending(s => s.Term)
                           .FirstOrDefault();

            if (studentToDelete != null)
            {
                studentToDelete.IsDeleted = 1;
                studentRepository.SaveAll(students);
                return true;
            }
        }
        else
        {
            Student studentToDelete = students.FirstOrDefault(s => s.AdmissionNo == admissionNo && s.IsDeleted == 0);
            if (studentToDelete != null)
            {
                studentToDelete.IsDeleted = 1;
                studentRepository.SaveAll(students);
                return true;
            }
        }
        return false;
    }

    public bool IsAdmissionNoUnique(int admissionNo, int session, int term)
    {
        List<Student> students = GetAllStudents();
        var filteredStudents = students.FindAll(s => s.AdmissionNo == admissionNo && s.Session == session && s.Term == term && s.IsDeleted == 0);
        return filteredStudents.Count == 0;
    }

    public List<Student> FilterData(List<Student> data, int session, int term)
    {
        return data.Where(s => s.Session == session && s.Term == term && s.IsDeleted == 0).ToList();
    }

    public List<Student> DescendingFilterData(List<Student> data)
    {
        return data.Where(student => student.IsDeleted == 0)
                   .OrderByDescending(student => student.Average)
                   .ToList();
    }

    public Student FilterStudentData(List<Student> students, int studentClass)
    {
        return students.Where(s => s.Class == studentClass && s.IsDeleted == 0)
                      .OrderByDescending(s => s.Session)
                      .ThenByDescending(s => s.Term)
                      .FirstOrDefault();
    }
 
    public List<Student> FilterRangeData(List<Student> data, int admissionNoFrom, int admissionNoTo)
    {
        return data.Where(s => s.AdmissionNo >= admissionNoFrom && s.AdmissionNo <= admissionNoTo && s.IsDeleted == 0).ToList();
    }

    public List<Student> FilterAndSortData(List<Student> data)
    {
        return data.Where(student => student.IsDeleted == 0)
                    .OrderBy(student => student.Term)
                    .ToList();
    }
}