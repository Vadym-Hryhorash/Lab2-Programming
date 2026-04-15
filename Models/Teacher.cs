using System;
using System.Collections.Generic;

namespace Lab2_Programming.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ThirdName { get; set; }

    public string TeacherClass { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int Salary { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
