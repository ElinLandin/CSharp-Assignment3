using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestcoastEducationDesktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";

    [RelayCommand]
    private void GoToCourses()
    {
        
    }

    [RelayCommand]
    private void GoToStudents()
    {
        
    }

    [RelayCommand]
    private void GoToTeachers()
    {
        
    }

}
