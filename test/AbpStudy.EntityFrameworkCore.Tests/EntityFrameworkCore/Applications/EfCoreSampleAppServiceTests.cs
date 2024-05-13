using AbpStudy.Samples;
using Xunit;

namespace AbpStudy.EntityFrameworkCore.Applications;

[Collection(AbpStudyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpStudyEntityFrameworkCoreTestModule>
{

}
