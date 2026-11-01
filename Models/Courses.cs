using System;
using System.Collections.Generic;
using System.Linq;

namespace WestcoastEducationDesktop.Models;

public class Courses
{
    private List<CourseContent> courseContent =[];

    public void AddCourseContent(string topic)
    {
        courseContent.Add(new CourseContent { Topic = topic });
    }

    private class CourseContent
    {
        public string Topic { get; set; } = "";
    }

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
                $"Startdatum: {StartDate:yyyy-MM-dd} Slutdatum: {EndDate:yyyy-MM-dd} Kursform: {courseFormat}, " +
                $"Kursinnehåll: {string.Join(", ", courseContent.Select(c => c.Topic))}";
    }

}