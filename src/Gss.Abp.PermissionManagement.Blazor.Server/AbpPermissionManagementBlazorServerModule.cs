using Gss.Abp.AspNetCore.Components.Server.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Gss.Abp.PermissionManagement.Blazor.Server;
[DependsOn(
    typeof(AbpPermissionManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
)]
public class AbpPermissionManagementBlazorServerModule : AbpModule
{
}
