using Gss.Abp.BootstrapUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Security;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Gss.Abp.AspNetCore.Components.Web.Theming;
[DependsOn(
    typeof(AbpBootstrapUIModule),
    typeof(AbpUiNavigationModule)
    )]
public class AbpAspNetCoreComponentsWebThemingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDynamicLayoutComponentOptions>(options =>
        {
            options.Components.Add(typeof(AbpAuthenticationState), null);
        });
    }
}

