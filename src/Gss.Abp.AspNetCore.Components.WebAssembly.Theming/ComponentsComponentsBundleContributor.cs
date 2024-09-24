using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Bundling;

namespace Gss.Abp.AspNetCore.Components.WebAssembly.Theming;
public class ComponentsComponentsBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
        context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/lang-utils.js");
        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/lang-utils.js");
        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/authentication-state-listener.js");
        context.Add("_content/BootstrapBlazor/js/bootstrap.blazor.bundle.min.js");
    }

    public void AddStyles(BundleContext context)
    {
        //if (!context.InteractiveAuto)
        //{
        //    context.BundleDefinitions.Insert(0, new BundleDefinition
        //    {
        //        Source = "_content/Volo.Abp.AspNetCore.Components.WebAssembly.Theming/libs/bootstrap/css/bootstrap.min.css"
        //    });
        //    context.BundleDefinitions.Insert(1, new BundleDefinition
        //    {
        //        Source = "_content/Volo.Abp.AspNetCore.Components.WebAssembly.Theming/libs/fontawesome/css/all.css"
        //    });
        //}

        context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/css/abp.css");
        context.Add("_content/Volo.Abp.AspNetCore.Components.WebAssembly.Theming/libs/flag-icon/css/flag-icon.css");
        context.Add("_content/BootstrapBlazor.FontAwesome/css/font-awesome.min.css");
        context.Add("_content/BootstrapBlazor/css/bootstrap.blazor.bundle.min.css");
    }
}
