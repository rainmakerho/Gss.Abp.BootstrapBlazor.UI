using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Gss.Abp.SettingManagement.Blazor;
public class SettingComponentCreationContext : IServiceProviderAccessor
{
    public IServiceProvider ServiceProvider { get; }

    public List<SettingComponentGroup> Groups { get; private set; }

    public SettingComponentCreationContext(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        Groups = new List<SettingComponentGroup>();
    }

    public void Normalize()
    {
        Order();
    }

    private void Order()
    {
        Groups = Groups.OrderBy(item => item.Order).ThenBy(item => item.DisplayName).ToList();
    }
}

