using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Toolbars;
public class ToolbarItem
{
    public Type ComponentType
    {
        get => _componentType;
        set => _componentType = Check.NotNull(value, nameof(value));
    }
    private Type _componentType = default!;

    public int Order { get; set; }

    public ToolbarItem(Type componentType, int order = 0)
    {
        Order = order;
        ComponentType = Check.NotNull(componentType, nameof(componentType));
    }
}

