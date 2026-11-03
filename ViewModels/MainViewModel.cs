using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestcoastEducationDesktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    [ObservableProperty]
    public partial object CurrentView { get; set; } = new CoursesViewModel();

    [RelayCommand]
    private void GoToCourses()
    {
        CurrentView = new CoursesViewModel();
    }

    [RelayCommand]
    private void GoToStudents()
    {
        CurrentView = new StudentsViewModel();
    }

    [RelayCommand]
    private void GoToTeachers()
    {
        CurrentView = new TeachersViewModel();
    }

}
