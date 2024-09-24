using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Theming;
public class ThemeDictionary : Dictionary<Type, ThemeInfo>
{
    public ThemeInfo Add<TTheme>()
        where TTheme : ITheme
    {
        return Add(typeof(TTheme));
    }

    public ThemeInfo Add(Type themeType)
    {
        if (ContainsKey(themeType))
        {
            throw new AbpException("This theme is already added before: " + themeType.AssemblyQualifiedName);
        }

        return this[themeType] = new ThemeInfo(themeType);
    }
}

