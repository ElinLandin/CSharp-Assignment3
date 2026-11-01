using System;
using System.Collections.Generic;

namespace WestcoastEducationDesktop.Models;

public class Employee : Person
{
        public string? AreaOfExpertise { get; set; }
    public List<Courses> AssignedCourses { get; set; } = [];

    public override string ToString()
    {
        return base.ToString() +
            $", Kunskapsområde: {AreaOfExpertise}";
    }
}
