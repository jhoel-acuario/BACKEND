using ApiWEb.Models.DataModels;

namespace ApiWEb.Services
{
    public interface IStudentsInterface
    {
        IEnumerable<Student> GetStudentsCourses();
        IEnumerable<Student> GetStudentsNotCourses();
    }
}
