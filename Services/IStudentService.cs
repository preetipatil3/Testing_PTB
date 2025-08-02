using ParentTeacherBridge.API.Models;

namespace ParentTeacherBridge.API.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetStudentsByClassAsync(int classId);
        Task<SchoolClass?> GetClassByTeacherIdAsync(int teacherId);
        Task<Student?> GetStudentByIdAsync(int studentId);
    }
}
