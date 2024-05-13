using AbpStudy.BackGroundJobs;
using AbpStudy.Models;
using AbpStudy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace AbpStudy.Services
{
    
    public class DapperService:ApplicationService,ITransientDependency   
    {
        private readonly TeacherDapperRepository _teacherRepository;
        private readonly StudentDapperRepository _studentRepository;
        private readonly IBackgroundJobManager backgroundJobManager;

        public DapperService(TeacherDapperRepository teacherRepository, StudentDapperRepository studentRepository,IBackgroundJobManager backgroundJob)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            backgroundJobManager= backgroundJob;
        }

        public async Task<List<string>> GetAllTeacherNamesAsync()
        {

            return await _teacherRepository.GetAllPersonNamesAsync(); 

            //await backgroundJobManager.EnqueueAsync<TeacherFetchJob>(new TeacherFetchJob(_teacherRepository));

            //return new List<string>();
        }

        public async Task<IEnumerable<Student>> GetStudentDetailsByIdAsync(int studentId)
        {
            return await _studentRepository.GetDetailsByStudentIdAsync(studentId);
        }

  
        public async Task<int> UpdateStudentDetails(int studentId, string name, string rollNo)
        { 
            return await _studentRepository.UpdateStudentDetails(studentId, name, rollNo);
        }


    }

    



}
