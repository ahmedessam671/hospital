using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Patient
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    public DateTime? BirthDate { get; set; }

    // Brief description of illness
    public string Illness { get; set; }

    // The doctor assigned (optional)
    public int? DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
