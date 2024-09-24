using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.BootstrapUI.Components;
public partial class ToolbarButton
{
    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public string Icon { get; set; } = "";

    [Parameter]
    public string Text { get; set; } = default!;

    [Parameter]
    public Func<Task> Clicked { get; set; } = default!;

    [Parameter]
    public bool Disabled { get; set; }
}

