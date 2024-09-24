using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.WebAssembly.BasicTheme;
public class AuthenticationOptions
{
    public string LoginUrl { get; set; } = "authentication/login";

    public string LogoutUrl { get; set; } = "authentication/logout";
}
