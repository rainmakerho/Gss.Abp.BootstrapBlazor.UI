using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
public class PageToolbarContributionContext
{

    public IServiceProvider ServiceProvider { get; }


    public PageToolbarItemList Items { get; }

    public PageToolbarContributionContext(
         IServiceProvider serviceProvider)
    {
        ServiceProvider = Check.NotNull(serviceProvider, nameof(serviceProvider));
        Items = new PageToolbarItemList();
    }
}
