using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestcoastEducationDesktop.Models;

namespace WestcoastEducationDesktop.Services;

public class StudentServices
{
        public async Task<List<Student>> List()
    {
        using var httpService = new HttpService<Student>();
        return await httpService.Get("students");
    }

    public async Task Add(Student student)
    {
        using var httpService = new HttpService<Student>();
        await httpService.Post("students", student);
    }
}
