﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gss.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
public interface IPageToolbarContributor
{
    Task ContributeAsync(PageToolbarContributionContext context);
}

