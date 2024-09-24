using Gss.Abp.SettingManagement.Blazor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.FeatureManagement.Localization;
using Volo.Abp.FeatureManagement;
using Microsoft.Extensions.DependencyInjection;
using Gss.Abp.FeatureManagement.Blazor.Components.FeatureSettingGroup;

namespace Gss.Abp.FeatureManagement.Blazor.Settings;
public class FeatureSettingManagementComponentContributor : ISettingComponentContributor
{
    public virtual async Task ConfigureAsync(SettingComponentCreationContext context)
    {
        if (!await CheckPermissionsInternalAsync(context))
        {
            return;
        }

        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpFeatureManagementResource>>();
        context.Groups.Add(
            new SettingComponentGroup(
                "Volo.Abp.Feature",
                l["Permission:FeatureManagement"],
                typeof(FeatureSettingManagementComponent)
            )
        );
    }

    public virtual async Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context)
    {
        return await CheckPermissionsInternalAsync(context);
    }

    protected virtual async Task<bool> CheckPermissionsInternalAsync(SettingComponentCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

        return await authorizationService.IsGrantedAsync(FeatureManagementPermissions.ManageHostFeatures);
    }
}
