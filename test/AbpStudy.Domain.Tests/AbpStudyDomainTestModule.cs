using Volo.Abp.Modularity;

namespace AbpStudy;

[DependsOn(
    typeof(AbpStudyDomainModule),
    typeof(AbpStudyTestBaseModule)
)]
public class AbpStudyDomainTestModule : AbpModule
{

}
