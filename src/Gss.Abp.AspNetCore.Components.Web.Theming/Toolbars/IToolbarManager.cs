using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Toolbars;
public interface IToolbarManager
{
    Task<Toolbar> GetAsync(string name);
}

