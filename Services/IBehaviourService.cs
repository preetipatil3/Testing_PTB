using ParentTeacherBridge.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Services
{
    public interface IBehaviourService
    {

            Task<IEnumerable<Behaviour>> GetBehavioursByTeacherAsync(int teacherId);
            Task<Behaviour> GetBehaviourByIdAsync(int teacherId, int behaviourId);
            Task<Behaviour> AddBehaviourAsync(int teacherId, Behaviour behaviour);
            Task<Behaviour> UpdateBehaviourAsync(int teacherId, int behaviourId, Behaviour behaviour);
            Task<bool> DeleteBehaviourAsync(int teacherId, int behaviourId);
      }
 
}
