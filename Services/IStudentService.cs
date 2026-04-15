using Lab2_Programming.Models;

namespace Lab2_Programming.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudentsOrderByClass();
        Student GetStudentInfoById(int id);
        void DeleteStudent(int id);
        void AddStudent(Student student, string className);
        void UpdateStudent(Student student, string className);
    }
}
