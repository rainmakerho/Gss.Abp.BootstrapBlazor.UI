﻿using BootstrapBlazor.Components;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.BootstrapUI.Components;
public partial class SubmitButton
{
    protected bool Submiting { get; set; }

    [Parameter]
    public string Form { get; set; } = default!;

    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Submit;

    [Parameter]
    public Color Color { get; set; } = Color.Primary;

    [Parameter]
    public bool PreventDefaultOnSubmit { get; set; } = true;

    [Parameter]
    public bool Block { get; set; }

    [Parameter]
    public bool? Disabled { get; set; }

    [Parameter]
    public string SaveResourceKey { get; set; } = "Save";

    [Parameter]
    public EventCallback Clicked { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Inject]
    protected IStringLocalizer<AbpUiResource> StringLocalizer { get; set; } = default!;

    protected bool IsDisabled
        => Disabled == true || Submiting;

    protected bool IsLoading
        => Submiting;

    protected string SaveString
        => StringLocalizer[SaveResourceKey];

    protected virtual async Task OnClickedHandler()
    {
        try
        {
            Submiting = true;

            await Clicked.InvokeAsync(null);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            Submiting = false;

            await InvokeAsync(StateHasChanged);
        }
    }
}

