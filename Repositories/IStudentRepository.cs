using ParentTeacherBridge.API.Models;

namespace ParentTeacherBridge.API.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
   
        Task<SchoolClass?> GetClassByTeacherIdAsync(int teacherId);

        Task<Student?> GetStudentByIdAsync(int studentId);
    }
}
