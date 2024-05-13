using AbpStudy.EntityFrameworkCore;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace AbpStudy.Repository
{
    public class TeacherDapperRepository: DapperRepository<AbpStudyDbContext>, ITransientDependency
    {
        public TeacherDapperRepository(IDbContextProvider<AbpStudyDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }
        public virtual async Task<List<string>> GetAllPersonNamesAsync()
        {
            var dbConnection = await GetDbConnectionAsync();
            return (await dbConnection.QueryAsync<string>(
                "select teacher_name from teacher",
                transaction: await GetDbTransactionAsync())
            ).ToList();
        }

        

    }
}
