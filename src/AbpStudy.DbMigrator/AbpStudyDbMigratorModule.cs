using AbpStudy.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpStudy.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpStudyEntityFrameworkCoreModule),
    typeof(AbpStudyApplicationContractsModule)
    )]
public class AbpStudyDbMigratorModule : AbpModule
{
}
