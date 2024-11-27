using System;
using System.ComponentModel.DataAnnotations;

public class InterviewViewModel
{
    public Guid? InterviewId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public TimeSpan StartTime { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public TimeSpan FinishTime { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string UserId { get; set; }
}
