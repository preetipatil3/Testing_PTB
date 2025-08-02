using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParentTeacherBridge.API.DTO;
using ParentTeacherBridge.API.Models;
using ParentTeacherBridge.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentTeacherBridge.API.Controllers
{
    [Route("teacher/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IBehaviourService _behaviourService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService, IBehaviourService behaviourService, IMapper mapper, IStudentService studentService)
        {
            _teacherService = teacherService;
            _behaviourService = behaviourService;
            _mapper = mapper;
            _studentService = studentService;
        }

        //// GET: teacher/Teachers
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

        // GET: teacher/Teachers/5
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

        // PUT: teacher/Teachers/5
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

        //// POST: teacher/Teachers
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

        // DELETE: teacher/Teachers/5
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

        #region Behaviour
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
        //    behaviour.TeacherId = teacherId;
        //    var newBehaviour = await _behaviourService.AddBehaviourAsync(behaviour);
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
        #endregion

        [HttpGet("{teacherId}/behaviour")]
        public async Task<IActionResult> GetBehaviours(int teacherId)
        {
            var behaviours = await _behaviourService.GetBehavioursByTeacherAsync(teacherId);
            if (!behaviours.Any()) return Ok(new List<BehaviourDto>());

            return Ok(_mapper.Map<IEnumerable<BehaviourDto>>(behaviours));
        }

        [HttpGet("{teacherId}/behaviour/{behaviourId}")]
        public async Task<IActionResult> GetBehaviour(int teacherId, int behaviourId)
        {
            var behaviour = await _behaviourService.GetBehaviourByIdAsync(teacherId, behaviourId);
            if (behaviour == null) return NotFound("Behaviour record not found.");

            return Ok(_mapper.Map<BehaviourDto>(behaviour));
        }

        [HttpPost("{teacherId}/behaviour")]
        public async Task<IActionResult> AddBehaviour(int teacherId, [FromBody] CreateBehaviourDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var behaviour = _mapper.Map<Behaviour>(dto);
            behaviour.TeacherId = teacherId;

            var newBehaviour = await _behaviourService.AddBehaviourAsync(behaviour);
            var behaviourDto = _mapper.Map<BehaviourDto>(newBehaviour);

            return CreatedAtAction(nameof(GetBehaviour), new { teacherId, behaviourId = behaviourDto.BehaviourId }, behaviourDto);
        }

        [HttpPut("{teacherId}/behaviour/{behaviourId}")]
        public async Task<IActionResult> UpdateBehaviour(int teacherId, int behaviourId, [FromBody] UpdateBehaviourDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedBehaviour = _mapper.Map<Behaviour>(dto);
            var updated = await _behaviourService.UpdateBehaviourAsync(teacherId, behaviourId, updatedBehaviour);

            if (updated == null) return NotFound("Behaviour record not found.");
            return NoContent();
        }

        [HttpDelete("{teacherId}/behaviour/{behaviourId}")]
        public async Task<IActionResult> DeleteBehaviour(int teacherId, int behaviourId)
        {
            var deleted = await _behaviourService.DeleteBehaviourAsync(teacherId, behaviourId);
            if (!deleted) return NotFound("Behaviour record not found.");
            return NoContent();
        }

        #region StudentInfo
        //[HttpGet("{teacherId}/students")]
        //public async Task<IActionResult> GetStudentsByTeacher(int teacherId)
        //{
        //    var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
        //    if (teacher == null) return NotFound($"Teacher with ID {teacherId} not found.");

        //    var students = await _studentService.GetStudentsByClassAsync(teacher.ClassId);
        //    if (!students.Any()) return Ok(new List<Student>()); // Return empty list if no students

        //    return Ok(students);
        //}

        //[HttpGet("{teacherId}/students/{studentId}")]
        //public async Task<IActionResult> GetStudentInfo(int teacherId, int studentId)
        //{
        //    var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
        //    if (teacher == null) return NotFound($"Teacher with ID {teacherId} not found.");

        //    var student = await _studentService.GetStudentByIdAsync(studentId);
        //    if (student == null) return NotFound($"Student with ID {studentId} not found.");

        //    // Ensure student belongs to teacher's class
        //    if (student.ClassId != teacher.ClassId)
        //        return Forbid("You are not authorized to view this student's info.");

        //    return Ok(student);
        //} 
        #endregion


        #region studentinfo without mapper
        //[HttpGet("students")]
        //public async Task<IActionResult> GetAllStudents()
        //{
        //    try
        //    {
        //        var students = await _studentService.GetAllStudentsAsync();
        //        if (!students.Any())
        //            return NotFound("No students found.");

        //        return Ok(students); // Returns list of all students
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //} 
        #endregion

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                if (!students.Any())
                    return NotFound("No students found.");

                var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
                return Ok(studentDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        #region StudenrInfo without dto
        //[HttpGet("{teacherId}/students")]
        //public async Task<IActionResult> GetStudentsByTeacher(int teacherId)
        //{
        //    // Check if teacher exists
        //    var teacher = await _teacherService.GetTeacherByIdAsync(teacherId);
        //    if (teacher == null)
        //        return NotFound($"Teacher with ID {teacherId} not found.");

        //    // ✅ Fetch class where teacher is class teacher
        //    var schoolClass = await _studentService.GetClassByTeacherIdAsync(teacherId);
        //    if (schoolClass == null)
        //        return NotFound($"No class assigned to Teacher ID {teacherId}.");

        //    // ✅ Fetch students in that class
        //    var students = await _studentService.GetStudentsByClassAsync(schoolClass.ClassId);
        //    if (!students.Any())
        //        return Ok(new List<Student>()); // Return empty list instead of 404

        //    return Ok(students);
        //} 
        #endregion

        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid student ID");

                var student = await _studentService.GetStudentByIdAsync(id);
                if (student == null)
                    return NotFound($"Student with ID {id} not found.");

                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(studentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}