using System;
using System.Collections.ObjectModel;
using WestcoastEducationDesktop.Models;

namespace WestcoastEducationDesktop.ViewModels;

public class CoursesViewModel : ViewModelBase
{
    public ObservableCollection<Courses> Courses { get; } = new()
    {
        new Courses
        {
            CourseNumber = "CS101",
            CourseTitle = "Programmering",
            StartDate = new DateTime(2027, 1, 25),
            EndDate = new DateTime(2027, 3, 22),
            IsItOnline = false
        }
    };
}
