﻿using Gss.Abp.AspNetCore.Components.Web.BasicTheme;
using Gss.Abp.AspNetCore.Components.Web.Theming.Routing;
using Gss.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Gss.Abp.AspNetCore.Components.WebAssembly.Theming;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Gss.Abp.AspNetCore.Components.WebAssembly.BasicTheme;
[DependsOn(
    typeof(AbpAspNetCoreComponentsWebBasicThemeModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
    typeof(AbpHttpClientIdentityModelWebAssemblyModule)
    )]
public class AbpAspNetCoreComponentsWebAssemblyBasicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreComponentsWebAssemblyBasicThemeModule).Assembly);
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new BasicThemeToolbarContributor());
        });

        if (context.Services.ExecutePreConfiguredActions<AbpAspNetCoreComponentsWebOptions>().IsBlazorWebApp)
        {
            Configure<AuthenticationOptions>(options =>
            {
                options.LoginUrl = "Account/Login";
                options.LogoutUrl = "Account/Logout";
            });
        }
    }
}
