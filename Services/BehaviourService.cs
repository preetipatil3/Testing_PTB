using ParentTeacherBridge.API.Models;
using ParentTeacherBridge.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Services
{
    public class BehaviourService:IBehaviourService
    {

            private readonly IBehaviourRepository _behaviourRepository;

            public BehaviourService(IBehaviourRepository behaviourRepository)
            {
                _behaviourRepository = behaviourRepository;
            }

            public async Task<IEnumerable<Behaviour>> GetBehavioursByTeacherAsync(int teacherId)
            {
                return await _behaviourRepository.GetBehavioursByTeacherAsync(teacherId);
            }

            public async Task<Behaviour> GetBehaviourByIdAsync(int teacherId, int behaviourId)
            {
                return await _behaviourRepository.GetBehaviourByIdAsync(teacherId, behaviourId);
            }

            public async Task<Behaviour> AddBehaviourAsync(int teacherId, Behaviour behaviour)
            {
                behaviour.TeacherId = teacherId;
                behaviour.CreatedAt = DateTime.UtcNow;
                behaviour.UpdatedAt = DateTime.UtcNow;

                return await _behaviourRepository.AddBehaviourAsync(behaviour);
            }

            public async Task<Behaviour> UpdateBehaviourAsync(int teacherId, int behaviourId, Behaviour behaviour)
            {
                var existing = await _behaviourRepository.GetBehaviourByIdAsync(teacherId, behaviourId);
                if (existing == null) return null;

                existing.StudentId = behaviour.StudentId;
                existing.IncidentDate = behaviour.IncidentDate;
                existing.BehaviourCategory = behaviour.BehaviourCategory;
                existing.Severity = behaviour.Severity;
                existing.Description = behaviour.Description;
                existing.NotifyParent = behaviour.NotifyParent;
                existing.UpdatedAt = DateTime.UtcNow;

                return await _behaviourRepository.UpdateBehaviourAsync(existing);
            }

            public async Task<bool> DeleteBehaviourAsync(int teacherId, int behaviourId)
            {
                return await _behaviourRepository.DeleteBehaviourAsync(teacherId, behaviourId);
            }
        
    }


}
