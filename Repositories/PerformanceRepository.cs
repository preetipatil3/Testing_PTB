using ParentTeacherBridge.API.Data;
using ParentTeacherBridge.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ParentTeacherBridge.API.Repositories
{
    public class PerformanceRepository:IPerformanceRepository
    {
        private readonly ParentTeacherBridgeAPIContext _context;

            public PerformanceRepository(ParentTeacherBridgeAPIContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Performance>> GetPerformanceByStudentIdAsync(int studentId)
            {
                return await _context.Set<Performance>()
                                     .Include(p => p.Student)
                                     .Include(p => p.Subject)
                                     .Where(p => p.StudentId == studentId)
                                     .ToListAsync();
            }

            public async Task<Performance?> GetPerformanceByIdAsync(int id)
            {
                return await _context.Set<Performance>()
                                     .Include(p => p.Student)
                                     .Include(p => p.Subject)
                                     .FirstOrDefaultAsync(p => p.PerformanceId == id);
            }

            public async Task<Performance> AddPerformanceAsync(Performance performance)
            {
                performance.CreatedAt = DateTime.UtcNow;
                performance.UpdatedAt = DateTime.UtcNow;
                _context.Add(performance);
                await _context.SaveChangesAsync();
                return performance;
            }

        public async Task<Performance?> UpdatePerformanceAsync(Performance performance)
        {
            var existing = await _context.Performance.FindAsync(performance.PerformanceId);
            if (existing == null) return null;

            // ✅ Update fields safely
            existing.StudentId = performance.StudentId;
            existing.TeacherId = performance.TeacherId;
            existing.SubjectId = performance.SubjectId;
            existing.ExamType = performance.ExamType;
            existing.MarksObtained = performance.MarksObtained;
            existing.MaxMarks = performance.MaxMarks;
            existing.Percentage = performance.Percentage;
            existing.Grade = performance.Grade;
            existing.ExamDate = performance.ExamDate;
            existing.Remarks = performance.Remarks;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }



        //public async Task<Performance?> UpdatePerformanceAsync(Performance performance)
        //{
        //    var existing = await _context.Set<Performance>().FindAsync(performance.PerformanceId);
        //    if (existing == null) return null;

        //    _context.Entry(existing).CurrentValues.SetValues(performance);
        //    existing.UpdatedAt = DateTime.UtcNow;

        //    await _context.SaveChangesAsync();
        //    return existing;
        //}

        public async Task<bool> DeletePerformanceAsync(int id)
            {
                var performance = await _context.Set<Performance>().FindAsync(id);
                if (performance == null) return false;

                _context.Remove(performance);
                await _context.SaveChangesAsync();
                return true;
            }
        
    }


}
