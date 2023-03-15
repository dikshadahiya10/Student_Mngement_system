using System;
using System.Collections.Generic;

namespace Student_Mngement_system.Entities;

public partial class StudentMangement
{
    public int Id { get; set; }

    public string? Studentname { get; set; }

    public string? Image { get; set; }

    public string? Dob { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Grade { get; set; }

    public string? Documents { get; set; }

    public string? Descriptions { get; set; }
}
