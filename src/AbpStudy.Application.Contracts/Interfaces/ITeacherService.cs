using AbpStudy.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpStudy.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> ExecuteGetDetailsById(int teacherId);
    }
}
