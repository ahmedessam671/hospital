using Hospital.Models;
using System.ComponentModel.DataAnnotations;

public enum EmploymentType
{
    FullTime,
    PartTime
}

public class Staff
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; }

    [Required, MaxLength(20)]
    public string NationalId { get; set; }

    [MaxLength(100)]
    public string JobTitle { get; set; }

    public decimal Salary { get; set; }

    public EmploymentType EmploymentType { get; set; }

    public int? ClinicId { get; set; }
    public Clinic Clinic { get; set; }
}
