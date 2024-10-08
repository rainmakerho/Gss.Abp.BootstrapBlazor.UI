﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.Timing;
using Gss.Abp.SettingManagement.Blazor.Pages.SettingManagement.TimeZoneSettingGroup;

namespace Gss.Abp.SettingManagement.Blazor.Settings;
public class TimeZonePageContributor : ISettingComponentContributor
{
    public async Task ConfigureAsync(SettingComponentCreationContext context)
    {
        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpSettingManagementResource>>();
        if (context.ServiceProvider.GetRequiredService<IClock>().SupportsMultipleTimezone)
        {
            context.Groups.Add(
                new SettingComponentGroup(
                    "Volo.Abp.TimeZone",
                    l["Menu:TimeZone"],
                    typeof(TimeZoneSettingGroupViewComponent)
                )
            );
        }
    }

    public async Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context)
    {
        var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

        return await authorizationService.IsGrantedAsync(SettingManagementPermissions.TimeZone);
    }
}

