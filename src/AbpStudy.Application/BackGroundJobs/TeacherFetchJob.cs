using AbpStudy.Models;
using AbpStudy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace AbpStudy.BackGroundJobs
{
    public class TeacherFetchJob : AsyncBackgroundJob<Teacher>, ITransientDependency
    {
        private readonly TeacherDapperRepository _teacherRepository;

        public TeacherFetchJob(TeacherDapperRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async override Task ExecuteAsync(Teacher teacher)
        {
            var teacherNames = await _teacherRepository.GetAllPersonNamesAsync();

            LogTeacherNames(teacherNames);
        }
        private void LogTeacherNames(List<string> teacherNames)
        {
            
            foreach (var name in teacherNames)
            {
                Console.WriteLine($"Teacher Name: {name}");
            }
        }
    }
}
