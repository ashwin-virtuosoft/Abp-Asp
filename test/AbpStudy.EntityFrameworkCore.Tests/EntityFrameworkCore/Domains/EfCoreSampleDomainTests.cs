using AbpStudy.Samples;
using Xunit;

namespace AbpStudy.EntityFrameworkCore.Domains;

[Collection(AbpStudyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpStudyEntityFrameworkCoreTestModule>
{

}
