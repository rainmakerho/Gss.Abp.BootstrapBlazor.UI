using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
public class PageToolbarItem
{

    public Type ComponentType { get; }

    public Dictionary<string, object?>? Arguments { get; set; }

    public int Order { get; set; }

    public PageToolbarItem(
        Type componentType,
        Dictionary<string, object?>? arguments = null,
        int order = 0)
    {
        ComponentType = Check.NotNull(componentType, nameof(componentType));
        Arguments = arguments;
        Order = order;
    }
}

