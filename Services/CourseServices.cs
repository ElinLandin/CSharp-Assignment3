using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestcoastEducationDesktop;
using WestcoastEducationDesktop.Models;

namespace WestcoastEducationDesktop.Services;

public class CourseServices
{
    public async Task<List<Courses>> List()
    {
        using var httpService = new HttpService<Courses>();
        return await httpService.Get("courses");
    }

    public async Task Add(Courses course)
    {
        using var httpService = new HttpService<Courses>();
        await httpService.Post("courses", course);
    }

    public async Task Delete(string id)
    {
        using var httpService = new HttpService<Courses>();
        await httpService.Delete("courses", id);
    }
}
