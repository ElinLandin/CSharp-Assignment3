using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WestcoastEducationDesktop.Models;

public class Teacher : Person
{

    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    
    public string? Id { get; set; }
    public string? AreaOfExpertise { get; set; }
    public List<Courses> AssignedCourses { get; set; } = [];

    public override string ToString()
    {
        return base.ToString() +
            $", Kunskapsområde: {AreaOfExpertise}";
    }
}
