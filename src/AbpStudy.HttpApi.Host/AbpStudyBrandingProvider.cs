using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpStudy;

[Dependency(ReplaceServices = true)]
public class AbpStudyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpStudy";
}
