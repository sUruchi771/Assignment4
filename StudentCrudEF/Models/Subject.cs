using System;
using System.Collections.Generic;

namespace StudentCrudEF.Models;

public partial class Subject
{
    public int SubId { get; set; }

    public string? SubName { get; set; }

    public int? MaxMarks { get; set; }

    public int? MarksObtained { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
