using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParentTeacherBridge.API.Models;

public partial class Behaviour
{
    [Key]
    public int BehaviourId { get; set; }

    [Required(ErrorMessage = "Student ID is required.")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Teacher ID is required.")]
    public int TeacherId { get; set; }

    [Required(ErrorMessage = "Incident date is required.")]
    public DateTime IncidentDate { get; set; }

    [Required(ErrorMessage = "Behaviour category is required.")]
    [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
    public string BehaviourCategory { get; set; }

    [Required(ErrorMessage = "Severity is required.")]
    [RegularExpression("^(Low|Medium|High)$", ErrorMessage = "Severity must be Low, Medium, or High.")]
    public string Severity { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    public bool NotifyParent { get; set; } = false;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


    //public int BehaviourId { get; set; }

    //public int? StudentId { get; set; }

    //public int? TeacherId { get; set; }

    //public DateOnly? IncidentDate { get; set; }

    //public string? BehaviourCategory { get; set; }

    //public string? Severity { get; set; }

    //public string? Description { get; set; }

    //public bool? NotifyParent { get; set; }

    //public DateTime? CreatedAt { get; set; }

    //public DateTime? UpdatedAt { get; set; }

    //public virtual Student? Student { get; set; }

    //public virtual Teacher? Teacher { get; set; }
}
