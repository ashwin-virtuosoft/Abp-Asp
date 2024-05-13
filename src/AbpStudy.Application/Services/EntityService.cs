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
    public class EntityService:ApplicationService
    {
        private readonly IJobPortalService  _jobPortalService;

        public EntityService(IJobPortalService jobPortalService)
        {
            _jobPortalService = jobPortalService;
        }

        public async Task<List<JobPortalDto>> GetJobPortals(int empId)
        {
            return await _jobPortalService.GetJobPortalDetails(empId);
        }

        public async Task<List<JobAllDetailsDto>> GetJobAllDetails(int employeeId)
        {
            return await _jobPortalService.GetAllDetails(employeeId);
        }
    }
}
