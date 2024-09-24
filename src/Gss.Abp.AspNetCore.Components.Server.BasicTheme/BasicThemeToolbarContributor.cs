using Gss.Abp.AspNetCore.Components.Server.BasicTheme.Themes.Basic;
using Gss.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.Server.BasicTheme;
public class BasicThemeToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            //context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            //context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
        }

        return Task.CompletedTask;
    }
}

