using Hospital.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Clinic
{
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; }

    public string Location { get; set; }

    // doctors in this clinic (many-to-many)
    public ICollection<Doctor> Doctors { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
