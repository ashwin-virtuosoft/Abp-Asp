using AbpStudy.Models;
using AbpStudy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace AbpStudy.Services
{
    public class JobPortalDapperService : ApplicationService, ITransientDependency
    {
        private JobPortalDapperRepository _jobportalDapperRepository;

        public JobPortalDapperService(JobPortalDapperRepository jobportalDapperRepository)
        {
            _jobportalDapperRepository = jobportalDapperRepository;
        }

        public async Task<IEnumerable<JobportalDetails>> GetJobportalDetails(int empId)
        {
            return await _jobportalDapperRepository.GetJobportalDetails(empId);
        }

        public async Task<List<JobDetails>> GetJobDetails(string Department,Decimal Salary)
        {
            return await _jobportalDapperRepository.GetJobDetailsBySalorDept(Department, Salary);
        }

        public async Task<List<JobAllDetails>> GetAllDetails(int employeeId)
        {
            return await _jobportalDapperRepository.GetAllDetails(employeeId);
        }

    }
}
