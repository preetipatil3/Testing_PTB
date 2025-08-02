using ParentTeacherBridge.API.Models;
using ParentTeacherBridge.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Services
{
    public class BehaviourService:IBehaviourService
    {

            private readonly IBehaviourRepository _repository;

            public BehaviourService(IBehaviourRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Behaviour>> GetBehavioursByTeacherAsync(int teacherId)
            {
                return await _repository.GetBehavioursByTeacherAsync(teacherId);
            }

            public async Task<Behaviour?> GetBehaviourByIdAsync(int teacherId, int behaviourId)
            {
                return await _repository.GetBehaviourByIdAsync(teacherId, behaviourId);
            }

            public async Task<Behaviour> AddBehaviourAsync(Behaviour behaviour)
            {
                behaviour.CreatedAt = DateTime.UtcNow;
                behaviour.UpdatedAt = DateTime.UtcNow;
                return await _repository.AddBehaviourAsync(behaviour);
            }

            public async Task<Behaviour?> UpdateBehaviourAsync(int teacherId, int behaviourId, Behaviour updatedBehaviour)
            {
                var existingBehaviour = await _repository.GetBehaviourByIdAsync(teacherId, behaviourId);
                if (existingBehaviour == null) return null;

                // Update fields
                existingBehaviour.StudentId = updatedBehaviour.StudentId;
                existingBehaviour.IncidentDate = updatedBehaviour.IncidentDate;
                existingBehaviour.BehaviourCategory = updatedBehaviour.BehaviourCategory;
                existingBehaviour.Severity = updatedBehaviour.Severity;
                existingBehaviour.Description = updatedBehaviour.Description;
                existingBehaviour.NotifyParent = updatedBehaviour.NotifyParent;
                existingBehaviour.UpdatedAt = DateTime.UtcNow;

                return await _repository.UpdateBehaviourAsync(existingBehaviour);
            }

            public async Task<bool> DeleteBehaviourAsync(int teacherId, int behaviourId)
            {
                return await _repository.DeleteBehaviourAsync(teacherId, behaviourId);
            }
        
    //private readonly IBehaviourRepository _behaviourRepository;

    //public BehaviourService(IBehaviourRepository behaviourRepository)
    //{
    //    _behaviourRepository = behaviourRepository;
    //}

    //public async Task<IEnumerable<Behaviour>> GetBehavioursByTeacherAsync(int teacherId)
    //{
    //    return await _behaviourRepository.GetBehavioursByTeacherAsync(teacherId);
    //}

    //public async Task<Behaviour> GetBehaviourByIdAsync(int teacherId, int behaviourId)
    //{
    //    return await _behaviourRepository.GetBehaviourByIdAsync(teacherId, behaviourId);
    //}

    //public async Task<Behaviour> AddBehaviourAsync(int teacherId, Behaviour behaviour)
    //{
    //    behaviour.TeacherId = teacherId;
    //    behaviour.CreatedAt = DateTime.UtcNow;
    //    behaviour.UpdatedAt = DateTime.UtcNow;

    //    return await _behaviourRepository.AddBehaviourAsync(behaviour);
    //}

    //public async Task<Behaviour> UpdateBehaviourAsync(int teacherId, int behaviourId, Behaviour behaviour)
    //{
    //    var existing = await _behaviourRepository.GetBehaviourByIdAsync(teacherId, behaviourId);
    //    if (existing == null) return null;

    //    existing.StudentId = behaviour.StudentId;
    //    existing.IncidentDate = behaviour.IncidentDate;
    //    existing.BehaviourCategory = behaviour.BehaviourCategory;
    //    existing.Severity = behaviour.Severity;
    //    existing.Description = behaviour.Description;
    //    existing.NotifyParent = behaviour.NotifyParent;
    //    existing.UpdatedAt = DateTime.UtcNow;

    //    return await _behaviourRepository.UpdateBehaviourAsync(existing);
    //}

    //public async Task<bool> DeleteBehaviourAsync(int teacherId, int behaviourId)
    //{
    //    return await _behaviourRepository.DeleteBehaviourAsync(teacherId, behaviourId);
    //}

}


}
