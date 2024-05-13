using AbpStudy.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpStudy.Interfaces
{
    public interface IJobPortalService
    {
         Task<List<JobPortalDto>> GetJobPortalDetails(int empId);
         Task<List<JobAllDetailsDto>> GetAllDetails(int employeeId);
    }
}
