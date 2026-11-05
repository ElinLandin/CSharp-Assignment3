using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using WestcoastEducationDesktop.Models;
using WestcoastEducationDesktop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestcoastEducationDesktop.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    private readonly TeacherServices _teacherServices = new();

    public ObservableCollection<Teacher> Teachers { get; } = [];

    public TeachersViewModel()
    {
        Init();
    }

    private async void Init()
    {
        try
        {
            var teachers = await _teacherServices.List();

            Teachers.Clear();

            foreach (var teacher in teachers)
            {
                Teachers.Add(teacher);
            }
        }    
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);   
        }
    }

    [ObservableProperty]
    public partial string NewFirstName { get; set; } = "";

    [ObservableProperty]
    public partial string NewLastName { get; set; } = "";
  
    [ObservableProperty]
    public partial string NewPersonalIdNumber { get; set; } = "";

    [ObservableProperty]
    public partial string NewAreaOfExpertise { get; set; } = "";


    [RelayCommand]
    private async Task AddTeacher()
    {
        var teacher = new Teacher
        {
            FirstName = NewFirstName,
            LastName = NewLastName,
            PersonalIdNumber = NewPersonalIdNumber,
            AreaOfExpertise = NewAreaOfExpertise
        };

        try
        {
            await _teacherServices.Add(teacher);

            var savedTeachers = await _teacherServices.List();
            Teachers.Clear();

            foreach (var savedTeacher in savedTeachers)
            {
                Teachers.Add(savedTeacher);
            }

            NewFirstName = "";
            NewLastName = "";
            NewPersonalIdNumber = "";
            NewAreaOfExpertise = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fel: " + ex.Message);
        }
    }

    [RelayCommand]
    private async Task UpdateTeacher(Teacher teacher)
    {
        try
        {
            await _teacherServices.Update(teacher);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fel: " + ex.Message);
        }
    }

}
