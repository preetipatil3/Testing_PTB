using Microsoft.EntityFrameworkCore;
using ParentTeacherBridge.API.Data;
using ParentTeacherBridge.API.Models;

namespace ParentTeacherBridge.API.Repositories
{
    public class StudentRepository:IStudentRepository
    {

        private readonly ParentTeacherBridgeAPIContext _context;

        public StudentRepository(ParentTeacherBridgeAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
        {
            return await _context.Student
                                 .Where(s => s.ClassId == classId)
                                 .ToListAsync();
        }

        public async Task<SchoolClass?> GetClassByTeacherIdAsync(int teacherId)
        {
            return await _context.SchoolClass
                                 .FirstOrDefaultAsync(c => c.ClassTeacherId == teacherId);
        }

        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _context.Student
                                 .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }
    }
}
