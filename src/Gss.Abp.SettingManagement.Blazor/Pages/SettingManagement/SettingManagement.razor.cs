using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Localization;

namespace Gss.Abp.SettingManagement.Blazor.Pages.SettingManagement;
public partial class SettingManagement
{

    [Inject]
    protected IServiceProvider ServiceProvider { get; set; }

    protected SettingComponentCreationContext SettingComponentCreationContext { get; set; }

    [Inject]
    protected IOptions<SettingManagementComponentOptions> _options { get; set; }
    [Inject]
    protected IStringLocalizer<AbpSettingManagementResource> L { get; set; }

    protected SettingManagementComponentOptions Options => _options.Value;
    protected List<RenderFragment> SettingItemRenders { get; set; } = new List<RenderFragment>();

    protected string SelectedGroup;
    protected List<BreadcrumbItem> BreadcrumbItems = new List<BreadcrumbItem>();

    protected async override Task OnInitializedAsync()
    {
        BreadcrumbItems.Add(new BreadcrumbItem(@L["Settings"]));

        SettingComponentCreationContext = new SettingComponentCreationContext(ServiceProvider);

        foreach (var contributor in Options.Contributors)
        {
            await contributor.ConfigureAsync(SettingComponentCreationContext);
        }
        SettingComponentCreationContext.Normalize();
        SettingItemRenders.Clear();

        SelectedGroup = GetNormalizedString(SettingComponentCreationContext.Groups.First().Id);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Task.Yield();
            await InvokeAsync(StateHasChanged);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    protected virtual string GetNormalizedString(string value)
    {
        return value.Replace('.', '_');
    }
}

