using AbpStudy.DTOs;
using AbpStudy.EntityFrameworkCore;
using AbpStudy.Interfaces;
using AbpStudy.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpStudy.Repository
{
    public class TeacherEntityRepository : ITeacherService
    {
        private readonly AbpStudyDbContext _dbContext;

        public TeacherEntityRepository(AbpStudyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TeacherDto>> ExecuteGetDetailsById(int teacherId)
        {
            var teachers = await _dbContext.Teachers.FromSqlRaw("EXEC GetDetailsById @TeacherId", teacherId).ToListAsync();
            var teacherDtos = new List<TeacherDto>();

            foreach (var teacher in teachers)
            {
                teacherDtos.Add(new TeacherDto
                {
                    TeacherId = teacher.TeacherId,
                    TeacherName = teacher.TeacherName,
                    Age = teacher.Age,
                    BatchId = teacher.BatchId
                });
            }

            return teacherDtos;
        }
    }
}
