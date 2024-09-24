using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Security;
using Volo.Abp.UI.Navigation;

namespace Gss.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic;
public partial class MainLayout : IDisposable
{
    [Inject]
    protected IMenuManager MenuManager { get; set; }

    [Inject]
    protected ApplicationConfigurationChangedService ApplicationConfigurationChangedService { get; set; }

    protected ApplicationMenu Menu { get; set; }

    private List<MenuItem>? Menus { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Menu = await MenuManager.GetMainMenuAsync();
        Menus = Menu.Items.Select(Convert2MenuItem).ToList();
        ApplicationConfigurationChangedService.Changed += ApplicationConfigurationChanged;
    }

    private async void ApplicationConfigurationChanged()
    {
        Menu = await MenuManager.GetMainMenuAsync();
        Menus = Menu.Items.Select(Convert2MenuItem).ToList();
        await InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        ApplicationConfigurationChangedService.Changed -= ApplicationConfigurationChanged;
    }

    MenuItem Convert2MenuItem(ApplicationMenuItem menuItem)
    {
        var menu = new MenuItem
        {
            Text = menuItem.DisplayName,
            Icon = menuItem.Icon,
            Url = menuItem.Url == null ? "#" : menuItem.Url.TrimStart('~'),
            Target = menuItem.Target,

        };
        menu.Items = menuItem.Items.Select(Convert2MenuItem).ToList();

        return menu;
    }
}

