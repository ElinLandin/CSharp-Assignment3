using System;
using System.Collections.ObjectModel;
using WestcoastEducationDesktop.Models;
using CommunityToolkit.Mvvm.Input;

namespace WestcoastEducationDesktop.ViewModels;

public partial class CoursesViewModel : ViewModelBase
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

    public string NewCourseNumber { get; set; } = "";
    public string NewCourseTitle { get; set; } = "";


    [RelayCommand]
    private void AddCourse()
    {
        Courses.Add(new Courses
        {
            CourseNumber = NewCourseNumber,
            CourseTitle = NewCourseTitle,
            StartDate = DateTime.Today,
            EndDate = DateTime.Today,
            IsItOnline = false
        });
    }

    [RelayCommand]
    private void DeleteCourse(Courses course)
    {
        Courses.Remove(course);
    }

}
