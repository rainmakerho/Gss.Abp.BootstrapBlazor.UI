using Gss.Abp.FeatureManagement.Blazor.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Gss.Abp.TenantManagement.Blazor.Server;
[DependsOn(
    typeof(AbpTenantManagementBlazorModule),
    typeof(AbpFeatureManagementBlazorServerModule)
    )]
public class AbpTenantManagementBlazorServerModule : AbpModule
{

}

