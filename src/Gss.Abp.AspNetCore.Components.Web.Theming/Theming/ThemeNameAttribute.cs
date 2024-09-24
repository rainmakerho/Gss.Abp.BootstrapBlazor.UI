using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Theming;
[AttributeUsage(AttributeTargets.Class)]
public class ThemeNameAttribute : Attribute
{
    public string Name { get; set; }

    public ThemeNameAttribute(string name)
    {
        Name = name;
    }

    public static string GetName(Type themeType)
    {
        return themeType
                   .GetCustomAttributes(true)
                   .OfType<ThemeNameAttribute>()
                   .FirstOrDefault()?.Name ?? themeType.Name;
    }
}
