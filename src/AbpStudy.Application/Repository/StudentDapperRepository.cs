using AbpStudy.EntityFrameworkCore;
using AbpStudy.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace AbpStudy.Repository
{
    public class StudentDapperRepository : DapperRepository<AbpStudyDbContext>, ITransientDependency
    {
        private readonly IDbContextProvider<AbpStudyDbContext> _dbContextProvider;

        public StudentDapperRepository(IDbContextProvider<AbpStudyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        private IDbConnection GetDbConnection()
        {
            return _dbContextProvider.GetDbContext().Database.GetDbConnection();
        }


        public async Task<IEnumerable<Student>> GetDetailsByStudentIdAsync(int studentId)
        {
            using (var dbConnection = GetDbConnection())
            {
                return await dbConnection.QueryAsync<Student>(
                    "GetDetailsByStudentId",
                    new { StudId = studentId },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public async Task<int> UpdateStudentDetails(int studentId, string name, string rollNo)
        {
            try
            {
                using (var dbConnection = GetDbConnection())

                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@StudId", studentId);
                    parameters.Add("@name", name);
                    parameters.Add("@rollNo", rollNo);

                    return await dbConnection.ExecuteAsync(
                        "UpdateDetails",
                        parameters,
                        commandType: CommandType.StoredProcedure
                       
                    );
                }

            }catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
        }
    }



}

