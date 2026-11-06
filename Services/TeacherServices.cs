using System.Collections.Generic;
using System.Threading.Tasks;
using WestcoastEducationDesktop.Models;

namespace WestcoastEducationDesktop.Services;

public class TeacherServices
{
    public async Task<List<Teacher>> List()
    {
        using var httpService = new HttpService<Teacher>();
        return await httpService.Get("teachers");
    }

    public async Task Add(Teacher teacher)
    {
        using var httpService = new HttpService<Teacher>();
        await httpService.Post("teachers", teacher);
    }

    public async Task Update(Teacher teacher)
    {
        if (teacher.Id == null) return;

        using var httpService = new HttpService<Teacher>();
        await httpService.Put("teachers", teacher, teacher.Id);
    }
}
