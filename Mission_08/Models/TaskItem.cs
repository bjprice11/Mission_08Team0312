using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    public bool Completed { get; set; } = false;
}
