using ParentTeacherBridge.API.Models;
using ParentTeacherBridge.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Services
{
    public class PerformanceService:IPerformanceService
    {

            private readonly IPerformanceRepository _repository;

            public PerformanceService(IPerformanceRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Performance>> GetPerformanceByStudentIdAsync(int studentId)
            {
                return await _repository.GetPerformanceByStudentIdAsync(studentId);
            }

            public async Task<Performance?> GetPerformanceByIdAsync(int id)
            {
                return await _repository.GetPerformanceByIdAsync(id);
            }

            public async Task<Performance> AddPerformanceAsync(Performance performance)
            {
                performance.CreatedAt = DateTime.UtcNow;
                performance.UpdatedAt = DateTime.UtcNow;
                return await _repository.AddPerformanceAsync(performance);
            }

            public async Task<Performance?> UpdatePerformanceAsync(int id, Performance updatedPerformance)
            {
                updatedPerformance.PerformanceId = id;
                return await _repository.UpdatePerformanceAsync(updatedPerformance);
            }

            public async Task<bool> DeletePerformanceAsync(int id)
            {
                return await _repository.DeletePerformanceAsync(id);
            }
        }
    


}
