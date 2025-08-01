using Microsoft.AspNetCore.Mvc;
using ParentTeacherBridge.API.Models;
using ParentTeacherBridge.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IBehaviourService _behaviourService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        //// GET: admin/Teachers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        //{
        //    try
        //    {
        //        var teachers = await _teacherService.GetAllTeachersAsync();
        //        return Ok(teachers);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        // GET: admin/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid teacher ID");

                var teacher = await _teacherService.GetTeacherByIdAsync(id);

                if (teacher == null)
                    return NotFound($"Teacher with ID {id} not found");

                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: admin/Teachers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            try
            {
                if (id <= 0 || teacher == null || id != teacher.TeacherId)
                    return BadRequest("Invalid input data");

                if (string.IsNullOrWhiteSpace(teacher.Name))
                    return BadRequest("Teacher name is required");

                if (string.IsNullOrWhiteSpace(teacher.Email))
                    return BadRequest("Teacher email is required");

                var result = await _teacherService.UpdateTeacherAsync(teacher);

                if (!result)
                    return NotFound($"Teacher with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //// POST: admin/Teachers
        //[HttpPost]
        //public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        //{
        //    try
        //    {
        //        if (teacher == null)
        //            return BadRequest("Teacher data is required");

        //        if (string.IsNullOrWhiteSpace(teacher.Name))
        //            return BadRequest("Teacher name is required");

        //        if (string.IsNullOrWhiteSpace(teacher.Email))
        //            return BadRequest("Teacher email is required");

        //        var result = await _teacherService.CreateTeacherAsync(teacher);

        //        if (!result)
        //            return StatusCode(500, "Failed to create teacher");

        //        return CreatedAtAction(nameof(GetTeacher), new { id = teacher.TeacherId }, teacher);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        // DELETE: admin/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid teacher ID");

                var result = await _teacherService.DeleteTeacherAsync(id);

                if (!result)
                    return NotFound($"Teacher with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpGet("{teacherId}/behaviour")]
        //public async Task<IActionResult> GetBehaviours(int teacherId)
        //{
        //    var behaviours = await _behaviourService.GetBehavioursByTeacherAsync(teacherId);
        //    if (!behaviours.Any()) return Ok(new List<Behaviour>()); // Empty list instead of 404
        //    return Ok(behaviours);
        //}

        //[HttpGet("{teacherId}/behaviour/{behaviourId}")]
        //public async Task<IActionResult> GetBehaviour(int teacherId, int behaviourId)
        //{
        //    var behaviour = await _behaviourService.GetBehaviourByIdAsync(teacherId, behaviourId);
        //    if (behaviour == null) return NotFound($"Behaviour record not found.");
        //    return Ok(behaviour);
        //}

        //[HttpPost("{teacherId}/behaviour")]
        //public async Task<IActionResult> AddBehaviour(int teacherId, [FromBody] Behaviour behaviour)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var newBehaviour = await _behaviourService.AddBehaviourAsync(teacherId, behaviour);
        //    return CreatedAtAction(nameof(GetBehaviour), new { teacherId, behaviourId = newBehaviour.BehaviourId }, newBehaviour);
        //}

        //[HttpPut("{teacherId}/behaviour/{behaviourId}")]
        //public async Task<IActionResult> UpdateBehaviour(int teacherId, int behaviourId, [FromBody] Behaviour behaviour)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var updated = await _behaviourService.UpdateBehaviourAsync(teacherId, behaviourId, behaviour);
        //    if (updated == null) return NotFound("Behaviour record not found.");
        //    return NoContent();
        //}

        //[HttpDelete("{teacherId}/behaviour/{behaviourId}")]
        //public async Task<IActionResult> DeleteBehaviour(int teacherId, int behaviourId)
        //{
        //    var deleted = await _behaviourService.DeleteBehaviourAsync(teacherId, behaviourId);
        //    if (!deleted) return NotFound("Behaviour record not found.");
        //    return NoContent();
        //}

    }
}