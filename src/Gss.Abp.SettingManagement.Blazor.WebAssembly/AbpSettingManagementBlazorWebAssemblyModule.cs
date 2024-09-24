using Gss.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace Gss.Abp.SettingManagement.Blazor.WebAssembly;
[DependsOn(
    typeof(AbpSettingManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class AbpSettingManagementBlazorWebAssemblyModule : AbpModule
{
}

