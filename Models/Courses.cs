using System;
using System.Text.Json.Serialization;

namespace WestcoastEducationDesktop.Models;

public class Courses
{

    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }
    
//---------------------------------------------------------------------

    public required string CourseNumber { get; set; }
    public required string CourseTitle { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsItOnline { get; set; }


    public int GetLengthInDays => (EndDate - StartDate).Days + 1;
    public int GetLengthInWeeks => GetLengthInDays / 7;

    public string GetCourseLength()
    {
        if (GetLengthInDays >= 7)
        {
            return $"{GetLengthInWeeks} veckor";
        }

        return $"{GetLengthInDays} dagar";
    }

    //------------------------------------------------------------------
    public override string ToString()
    {

        string courseFormat = "Klassrum";

        if (IsItOnline)
        {
            courseFormat = "Distans";
        }

        return  $"Kursnummer: {CourseNumber}, Kurstitel: {CourseTitle}, Kurslängd: {GetCourseLength()}, " +
                $"Startdatum: {StartDate:yyyy-MM-dd} Slutdatum: {EndDate:yyyy-MM-dd} Kursform: {courseFormat}";
    }

}