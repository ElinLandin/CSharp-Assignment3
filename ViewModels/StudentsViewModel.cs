using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WestcoastEducationDesktop.Models;
using WestcoastEducationDesktop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestcoastEducationDesktop.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
     private readonly StudentServices _studentServices = new();

    public ObservableCollection<Student> Students { get; } = [];

    public StudentsViewModel()
    {
        Init();
    }

    private async void Init()
    {
        try
        {
            var students = await _studentServices.List();

            Students.Clear();

            foreach (var student in students)
            {
                Students.Add(student);
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



    [RelayCommand]
    private async Task AddStudent()
    {
        var student = new Student
        {
            FirstName = NewFirstName,
            LastName = NewLastName,
            PersonalIdNumber = NewPersonalIdNumber,
        };

        try
        {
            await _studentServices.Add(student);

            var savedStudents = await _studentServices.List();
            Students.Clear();

            foreach (var savedStudent in savedStudents)
            {
                Students.Add(savedStudent);
            }

            NewFirstName = "";
            NewLastName = "";
            NewPersonalIdNumber = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fel: " + ex.Message);
        }
    }
}
