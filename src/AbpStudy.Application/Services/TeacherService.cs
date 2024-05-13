using AbpStudy.DTOs;
using AbpStudy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpStudy.Services
{
    public class TeacherService:ApplicationService
    {
        private readonly ITeacherService teacherService;

        public TeacherService(ITeacherService teacher)
        {
            teacherService = teacher;
        }
        public async Task<List<TeacherDto>> GetDetailsById(int teacherId)      
        {
            return await teacherService.ExecuteGetDetailsById(teacherId);
        }
    }
}



