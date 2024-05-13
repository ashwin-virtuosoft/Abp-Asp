using AbpStudy.EntityFrameworkCore;
using AbpStudy.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace AbpStudy.Repository
{
    public class JobPortalDapperRepository : DapperRepository<AbpStudyDbContext>, ITransientDependency
    {
        private readonly IDbContextProvider<AbpStudyDbContext> _dbContextProvider;

        public JobPortalDapperRepository(IDbContextProvider<AbpStudyDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        private IDbConnection GetDbConnection()
        {
            return _dbContextProvider.GetDbContext().Database.GetDbConnection();
        }

        public async Task<IEnumerable<JobportalDetails>> GetJobportalDetails(int empId)
        {
            using (var dbCon = GetDbConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@employee_id", empId);


                    var dbContext = _dbContextProvider.GetDbContext();
                    var transaction = dbContext.Database.CurrentTransaction?.GetDbTransaction();


                    return await dbCon.QueryAsync<JobportalDetails>(
                        "GetJobPortalDetails",
                        parameters,
                        commandType: CommandType.StoredProcedure,
                        transaction: transaction
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                    throw;
                }
            }
        }


        // Another Approach without using Dynamic parameters --

        //public async Task<IEnumerable<JobportalDetails>> GetJobportalDetails(int empID)
        //{
        //    using (var dbConnection = GetDbConnection())
        //    {
        //        return await dbConnection.QueryAsync<JobportalDetails>(
        //            "GetJobPortalDetails",
        //            new { employeeId = empID },
        //            commandType: CommandType.StoredProcedure
        //        );
        //    }
        //}


        public async Task<List<JobDetails>> GetJobDetailsBySalorDept(string department, decimal salary)
        {
            try
            {
                using (var dbCon = GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Department", department);
                    parameters.Add("@Salary", salary);

                    var res = await dbCon.QueryAsync<JobDetails>(
                        "GetDetailsBySalorDept",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return res.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; 
            }
        }


        public async Task<List<JobAllDetails>> GetAllDetails(int employeeId)
        {
            try
            {
                using (var dbConnection = GetDbConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Employee_id", employeeId);

                    var jobAllDetailsDictionary = new Dictionary<int, JobAllDetails>();
                    var result = await dbConnection.QueryAsync<JobAllDetails, JobSeeker, JobAllDetails>(
                        sql: "GetAllJobDetails",
                        map: (jobAllDetails, jobSeeker) =>
                        {
                            if (!jobAllDetailsDictionary.TryGetValue(jobAllDetails.Employee_Id, out var jobDetails))
                            {
                                jobDetails = jobAllDetails;
                                jobDetails.jobSeekers = new List<JobSeeker>();
                                jobAllDetailsDictionary.Add(jobDetails.Employee_Id, jobDetails);
                            }

                            jobDetails.jobSeekers.Add(jobSeeker);
                            return jobDetails;
                        },
                        param: parameters,
                        splitOn: "JobSeeker_Id",
                        commandType: CommandType.StoredProcedure
                    );

                    return result?.Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }




    }
}
