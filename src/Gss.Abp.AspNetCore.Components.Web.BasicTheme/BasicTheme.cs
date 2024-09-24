using Gss.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic;
using Gss.Abp.AspNetCore.Components.Web.Theming.Layout;
using Gss.Abp.AspNetCore.Components.Web.Theming.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Gss.Abp.AspNetCore.Components.Web.BasicTheme;
[ThemeName(Name)]
public class BasicTheme : ITheme, ITransientDependency
{
    public const string Name = "Basic";

    public virtual Type GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
            case StandardLayouts.Account:
            case StandardLayouts.Empty:
                return typeof(MainLayout);
            default:
                return fallbackToDefault ? typeof(MainLayout) : typeof(NullLayout);
        }
    }
}
