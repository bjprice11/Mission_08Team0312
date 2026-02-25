using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission_08.Models;

public partial class TaskItem
{
    [Key]
    public int TaskId { get; set; }

    [Required(ErrorMessage = "Please enter a task name")]
    public string Task { get; set; } = null!;
    
    public string? DueDate { get; set; }

    [Required(ErrorMessage = "Please enter a task quadrant")]
    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    public int? Completed { get; set; }
}
