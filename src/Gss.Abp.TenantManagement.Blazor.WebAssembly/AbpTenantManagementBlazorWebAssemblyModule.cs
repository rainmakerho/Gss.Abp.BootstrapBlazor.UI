using Gss.Abp.FeatureManagement.Blazor.WebAssembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Gss.Abp.TenantManagement.Blazor.WebAssembly;
[DependsOn(
    typeof(AbpTenantManagementBlazorModule),
    typeof(AbpFeatureManagementBlazorWebAssemblyModule),
    typeof(AbpTenantManagementHttpApiClientModule)
    )]
public class AbpTenantManagementBlazorWebAssemblyModule : AbpModule
{

}


