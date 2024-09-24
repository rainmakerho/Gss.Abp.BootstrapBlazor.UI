using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Gss.Abp.SettingManagement.Blazor.Menus;
public class SettingManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var settingManagementPageOptions = context.ServiceProvider.GetRequiredService<IOptions<SettingManagementComponentOptions>>().Value;
        var settingPageCreationContext = new SettingComponentCreationContext(context.ServiceProvider);
        if (!settingManagementPageOptions.Contributors.Any() ||
            !(await CheckAnyOfPagePermissionsGranted(settingManagementPageOptions, settingPageCreationContext))
        )
        {
            return;
        }

        var l = context.GetLocalizer<AbpSettingManagementResource>();

        /* This may happen if MVC UI is being used in the same application.
         * In this case, we are removing the MVC setting management UI. */
        context.Menu.GetAdministration().TryRemoveMenuItem(SettingManagementMenus.GroupName);

        context.Menu
            .GetAdministration()
            .AddItem(
                new ApplicationMenuItem(
                    SettingManagementMenus.GroupName,
                    l["Settings"],
                    "~/setting-management",
                    icon: "fa fa-cog"
                ).RequireFeatures(SettingManagementFeatures.Enable)
            );
    }

    protected virtual async Task<bool> CheckAnyOfPagePermissionsGranted(
        SettingManagementComponentOptions settingManagementComponentOptions,
        SettingComponentCreationContext settingComponentCreationContext)
    {
        foreach (var contributor in settingManagementComponentOptions.Contributors)
        {
            if (await contributor.CheckPermissionsAsync(settingComponentCreationContext))
            {
                return true;
            }
        }
        return false;
    }
}
