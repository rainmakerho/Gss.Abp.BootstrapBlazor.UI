using Gss.Abp.AspNetCore.Components.WebAssembly.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;

namespace Gss.Abp.FeatureManagement.Blazor.WebAssembly;
[DependsOn(
    typeof(AbpFeatureManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
    typeof(AbpFeatureManagementHttpApiClientModule)
)]
public class AbpFeatureManagementBlazorWebAssemblyModule : AbpModule
{
}

