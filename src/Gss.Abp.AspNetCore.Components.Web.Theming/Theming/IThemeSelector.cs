﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.Theming;
public interface IThemeSelector
{
    ThemeInfo GetCurrentThemeInfo();
}
