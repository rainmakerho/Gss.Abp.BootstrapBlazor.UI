using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Layout;
public class PageHeaderOptions
{
    public bool RenderPageTitle { get; set; } = true;
    public bool RenderBreadcrumbs { get; set; } = true;
    public bool RenderToolbar { get; set; } = true;
}
