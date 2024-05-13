using AbpStudy.DTOs;
using AbpStudy.EntityFrameworkCore;
using AbpStudy.Interfaces;
using AbpStudy.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace AbpStudy.Repository
{
    public class JobPortalEntityRepository : IJobPortalService
    {
        private readonly AbpStudyDbContext _dbContext;

        public JobPortalEntityRepository(AbpStudyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<JobPortalDto>> GetJobPortalDetails(int empId)
        {
            var employeeIdParam = new SqlParameter("@employee_id", empId);

            var jobPortalDetails = await _dbContext.JobportalDetails
                                        .FromSqlRaw("EXEC GetJobPortalDetails @employee_id", employeeIdParam).ToListAsync();


            var jobPortalDtoList=new List<JobPortalDto>();

            foreach(var jobPortalDetail in jobPortalDetails)
            {
                var jobPortalDto = new JobPortalDto()
                {
                    EmployeeId = jobPortalDetail.Employee_Id,
                    EmployeeName = jobPortalDetail.Employee_Name,
                    Position = jobPortalDetail.Position,
                    Department = jobPortalDetail.Department,
                    HireDate = jobPortalDetail.Hire_Date,
                    DesiredPosition = jobPortalDetail.Desired_Position,
                    DesiredSalary = jobPortalDetail.Desired_Salary,
                    JoinDate = jobPortalDetail.Join_Date
                };

                jobPortalDtoList.Add(jobPortalDto);
            }
            return jobPortalDtoList;
        }

        public async Task<List<JobAllDetailsDto>> GetAllDetails(int employeeId)
        {
            try
            {
                var employeeIdParam = new SqlParameter("@Employee_id", employeeId);

                var jobAllDetails = await _dbContext.JobAllDetails
                    .FromSqlRaw("EXEC GetAllJobDetails @Employee_id", employeeIdParam)
                    .ToListAsync();

                var result = jobAllDetails.Select(j => new JobAllDetailsDto
                {
                    Employee_Id = j.Employee_Id,
                    Employee_Name = j.Employee_Name,
                    Position = j.Position,
                    Department = j.Department,
                    Hire_Date = j.Hire_Date,
                    jobSeekers = j.jobSeekers.Select(js => new DTOs.JobSeeker
                    {
                        JobSeeker_Id = js.JobSeeker_Id,
                        Jobeseeker_name = js.Jobeseeker_name,
                        Desired_Position = js.Desired_Position,
                        Desired_Salary = js.Desired_Salary,
                        Join_Date = js.Join_Date
                    }).ToList()
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }




    }
}
