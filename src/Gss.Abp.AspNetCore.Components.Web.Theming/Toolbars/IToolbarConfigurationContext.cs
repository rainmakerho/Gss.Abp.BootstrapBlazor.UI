using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Toolbars;
public interface IToolbarConfigurationContext : IServiceProviderAccessor
{
    Toolbar Toolbar { get; }

    IAuthorizationService AuthorizationService { get; }

    IStringLocalizerFactory StringLocalizerFactory { get; }

    Task<bool> IsGrantedAsync(string policyName);

    IStringLocalizer? GetDefaultLocalizer();


    public IStringLocalizer GetLocalizer<T>();


    public IStringLocalizer GetLocalizer(Type resourceType);
}

