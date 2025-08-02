using Microsoft.EntityFrameworkCore;
using ParentTeacherBridge.API.Models;
using ParentTeacherBridge.API.Repositories;

namespace ParentTeacherBridge.API.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllStudentsAsync();
        }
        public async Task<IEnumerable<Student>> GetStudentsByClassAsync(int classId)
        {
            return await _repository.GetStudentsByClassIdAsync(classId);
        }

        public async Task<SchoolClass?> GetClassByTeacherIdAsync(int teacherId)
        {
            return await _repository.GetClassByTeacherIdAsync(teacherId);
        }

        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _repository.GetStudentByIdAsync(studentId);
        }



    }
}
