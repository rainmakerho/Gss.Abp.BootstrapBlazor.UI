﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Gss.Abp.SettingManagement.Blazor;
public class SettingComponentGroup
{
    public const int DefaultOrder = 1000;

    public string Id
    {
        get => _id;
        set => _id = Check.NotNullOrWhiteSpace(value, nameof(Id));
    }
    private string _id;

    public string DisplayName
    {
        get => _displayName;
        set => _displayName = Check.NotNullOrWhiteSpace(value, nameof(DisplayName));
    }
    private string _displayName;

    public Type ComponentType
    {
        get => _componentType;
        set => _componentType = Check.NotNull(value, nameof(ComponentType));
    }
    private Type _componentType;

    public object Parameter { get; set; }

    public int Order { get; set; }

    public SettingComponentGroup( string id, string displayName,  Type componentType, object parameter = null, int order = DefaultOrder)
    {
        Id = id;
        DisplayName = displayName;
        ComponentType = componentType;
        Parameter = parameter;
        Order = order;
    }
}

