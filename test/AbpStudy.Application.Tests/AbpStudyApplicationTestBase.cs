using Volo.Abp.Modularity;

namespace AbpStudy;

public abstract class AbpStudyApplicationTestBase<TStartupModule> : AbpStudyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
