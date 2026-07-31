using Hospital.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    public int Id { get; set; }

    public DateTime AppointmentDate { get; set; }

    // Relationships
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public int ClinicId { get; set; }
    public Clinic Clinic { get; set; }

    // Optional status
    [MaxLength(50)]
    public string Status { get; set; } // e.g., Pending, Completed, Canceled
}
