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
}
