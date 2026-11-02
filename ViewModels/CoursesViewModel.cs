using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WestcoastEducationDesktop.Models;
using WestcoastEducationDesktop.Services;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace WestcoastEducationDesktop.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly CourseServices _courseServices = new();

    public CoursesViewModel()
    {
        Init();
    }

    private async void Init()
    {
        try
        {
            var courses = await _courseServices.List();

            Courses.Clear();

            foreach (var course in courses)
            {
                Courses.Add(course);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

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
