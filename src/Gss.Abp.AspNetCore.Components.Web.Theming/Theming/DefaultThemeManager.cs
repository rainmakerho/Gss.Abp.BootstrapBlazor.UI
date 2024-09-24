using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Theming;
public class DefaultThemeManager : IThemeManager, IScopedDependency, IServiceProviderAccessor
{
    public IServiceProvider ServiceProvider { get; }
    public ITheme CurrentTheme => GetCurrentTheme();

    private ITheme? _currentTheme;

    protected IThemeSelector ThemeSelector { get; }

    public DefaultThemeManager(
        IServiceProvider serviceProvider,
        IThemeSelector themeSelector)
    {
        ServiceProvider = serviceProvider;
        ThemeSelector = themeSelector;
    }

    protected virtual ITheme GetCurrentTheme()
    {
        if (_currentTheme != null)
        {
            return _currentTheme;
        }

        _currentTheme = (ITheme)ServiceProvider.GetRequiredService(ThemeSelector.GetCurrentThemeInfo().ThemeType);
        return CurrentTheme;
    }
}

