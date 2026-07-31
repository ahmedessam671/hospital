using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Doctor
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Specialty { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    // Treatment notes (optional) - maybe used when doctor prescribes
    public string TreatmentNotes { get; set; }

    // Many-to-many with Clinic (explicit join or implicit in EF Core)
    public ICollection<Clinic> Clinics { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
