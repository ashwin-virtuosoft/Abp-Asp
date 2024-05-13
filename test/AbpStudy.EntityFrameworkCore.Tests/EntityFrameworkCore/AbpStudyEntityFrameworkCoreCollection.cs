using Xunit;

namespace AbpStudy.EntityFrameworkCore;

[CollectionDefinition(AbpStudyTestConsts.CollectionDefinitionName)]
public class AbpStudyEntityFrameworkCoreCollection : ICollectionFixture<AbpStudyEntityFrameworkCoreFixture>
{

}
