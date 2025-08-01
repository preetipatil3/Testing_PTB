using ParentTeacherBridge.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Repositories
{
    public interface IBehaviourRepository
    {
            Task<IEnumerable<Behaviour>> GetBehavioursByTeacherAsync(int teacherId);
            Task<Behaviour> GetBehaviourByIdAsync(int teacherId, int behaviourId);
            Task<Behaviour> AddBehaviourAsync(Behaviour behaviour);
            Task<Behaviour> UpdateBehaviourAsync(Behaviour behaviour);
            Task<bool> DeleteBehaviourAsync(int teacherId, int behaviourId);
        
    }


}
