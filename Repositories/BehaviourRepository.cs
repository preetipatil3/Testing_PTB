using ParentTeacherBridge.API.Data;
using ParentTeacherBridge.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Repositories
{
    public class BehaviourRepository:IBehaviourRepository
    {

            private readonly AppDbContext _context;

            public BehaviourRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Behaviour>> GetBehavioursByTeacherAsync(int teacherId)
            {
                return await _context.Behaviours
                                     .Where(b => b.TeacherId == teacherId)
                                     .ToListAsync();
            }

            public async Task<Behaviour> GetBehaviourByIdAsync(int teacherId, int behaviourId)
            {
                return await _context.Behaviours
                                     .FirstOrDefaultAsync(b => b.BehaviourId == behaviourId && b.TeacherId == teacherId);
            }

            public async Task<Behaviour> AddBehaviourAsync(Behaviour behaviour)
            {
                _context.Behaviours.Add(behaviour);
                await _context.SaveChangesAsync();
                return behaviour;
            }

            public async Task<Behaviour> UpdateBehaviourAsync(Behaviour behaviour)
            {
                _context.Behaviours.Update(behaviour);
                await _context.SaveChangesAsync();
                return behaviour;
            }

            public async Task<bool> DeleteBehaviourAsync(int teacherId, int behaviourId)
            {
                var behaviour = await GetBehaviourByIdAsync(teacherId, behaviourId);
                if (behaviour == null) return false;

                _context.Behaviours.Remove(behaviour);
                await _context.SaveChangesAsync();
                return true;
            }
        
    }


}
