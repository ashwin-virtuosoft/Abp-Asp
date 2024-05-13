using Volo.Abp.Modularity;

namespace AbpStudy;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpStudyDomainTestBase<TStartupModule> : AbpStudyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
