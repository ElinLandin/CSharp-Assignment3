using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WestcoastEducationDesktop.Models;
using WestcoastEducationDesktop.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

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

    [ObservableProperty]
    public partial string NewCourseNumber { get; set; } = "";

    [ObservableProperty]
    public partial string NewCourseTitle { get; set; } = "";

    [ObservableProperty]
    public partial bool NewIsItOnline { get; set; } = false;

    [ObservableProperty]
    public partial DateTimeOffset? NewStartDate { get; set; } = DateTimeOffset.Now;

    [ObservableProperty]
    public partial DateTimeOffset? NewEndDate { get; set; } = DateTimeOffset.Now;


    [RelayCommand]
    private async Task AddCourse()
    {
        var course = new Courses
        {
            CourseNumber = NewCourseNumber,
            CourseTitle = NewCourseTitle,
            StartDate = NewStartDate?.DateTime ?? DateTime.Today,
            EndDate = NewEndDate?.DateTime ?? DateTime.Today,
            IsItOnline = NewIsItOnline
        };
    try
        {
            await _courseServices.Add(course);
            Courses.Add(course);
            NewCourseNumber = "";
            NewCourseTitle= "";
            NewIsItOnline = false;
            NewStartDate = DateTimeOffset.Now;
            NewEndDate = DateTimeOffset.Now;
        }
    catch (Exception ex)
        {
            Console.WriteLine("Fel: " + ex.Message);
        }    

    }

    [RelayCommand]
    private async Task DeleteCourse(Courses course)
    {
        if (string.IsNullOrWhiteSpace(course.Id))
            return;

        await _courseServices.Delete(course.Id);
        Courses.Remove(course);
    }

}
