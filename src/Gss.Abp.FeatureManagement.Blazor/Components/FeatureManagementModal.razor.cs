using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web.Configuration;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Gss.Abp.FeatureManagement.Blazor.Components;
public partial class FeatureManagementModal
{
    [Inject] protected IFeatureAppService FeatureAppService { get; set; }

    [Inject] protected IUiMessageService UiMessageService { get; set; }

    [Inject] protected IStringLocalizerFactory HtmlLocalizerFactory { get; set; }

    [Inject] protected IOptions<AbpLocalizationOptions> LocalizationOptions { get; set; }

    [Inject] protected ICurrentApplicationConfigurationCacheResetService CurrentApplicationConfigurationCacheResetService { get; set; }

    protected Modal Modal;

    protected string ProviderName;
    protected string ProviderKey;

    protected string SelectedTabName;

    protected List<FeatureGroupDto> Groups { get; set; }

    protected Dictionary<string, bool> ToggleValues;

    protected Dictionary<string, string> SelectionStringValues;

    public virtual async Task OpenAsync( string providerName, string providerKey = null)
    {
        try
        {
            ProviderName = providerName;
            ProviderKey = providerKey;

            ToggleValues = new Dictionary<string, bool>();
            SelectionStringValues = new Dictionary<string, string>();

            var result = await FeatureAppService.GetAsync(ProviderName, ProviderKey);

            Groups = result?.Groups ?? new List<FeatureGroupDto>();

            if (Groups.Any())
            {
                SelectedTabName = GetNormalizedGroupName(Groups.First().Name);
            }

            foreach (var featureGroupDto in Groups)
            {
                foreach (var featureDto in featureGroupDto.Features)
                {
                    if (featureDto.ValueType is ToggleStringValueType)
                    {
                        ToggleValues.Add(featureDto.Name, bool.Parse(featureDto.Value));
                    }

                    if (featureDto.ValueType is SelectionStringValueType)
                    {
                        SelectionStringValues.Add(featureDto.Name, featureDto.Value);
                    }
                }
            }

            await InvokeAsync(Modal.Show);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    public virtual Task CloseModal()
    {
        return InvokeAsync(Modal.Close);
    }

    protected virtual async Task SaveAsync()
    {
        try
        {
            var features = new UpdateFeaturesDto
            {
                Features = Groups.SelectMany(g => g.Features).Select(f => new UpdateFeatureDto
                {
                    Name = f.Name,
                    Value = f.ValueType is ToggleStringValueType ? ToggleValues[f.Name].ToString() :
                        f.ValueType is SelectionStringValueType ? SelectionStringValues[f.Name] : f.Value
                }).ToList()
            };

            await FeatureAppService.UpdateAsync(ProviderName, ProviderKey, features);

            await CurrentApplicationConfigurationCacheResetService.ResetAsync();

            await InvokeAsync(Modal.Close);
            await Notify.Success(L["SavedSuccessfully"]);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    public virtual async Task DeleteAsync( string providerName, string providerKey = null)
    {
        try
        {
            if (!await Message.Confirm(L["AreYouSureToResetToDefault"]))
            {
                return;
            }
            await FeatureAppService.DeleteAsync(ProviderName, ProviderKey);
            await Message.Success(L["ResetedToDefault"]);

            await CloseModal();
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    protected virtual string GetNormalizedGroupName(string name)
    {
        return "FeatureGroup_" + name.Replace(".", "_");
    }

    protected virtual string GetFeatureStyles(FeatureDto feature)
    {
        return $"margin-left: {feature.Depth * 20}px";
    }

    protected virtual bool IsDisabled(string providerName)
    {
        return providerName != ProviderName && providerName != DefaultValueFeatureValueProvider.ProviderName;
    }

    protected virtual async Task OnFeatureValueChangedAsync(string value, FeatureDto feature)
    {
        if (feature?.ValueType?.Validator.IsValid(value) == true)
        {
            feature.Value = value;
        }
        else
        {
            await UiMessageService.Warn(L["Volo.Abp.FeatureManagement:InvalidFeatureValue", feature.DisplayName]);
        }
    }

    protected virtual Task OnSelectedValueChangedAsync(bool value, FeatureDto feature)
    {
        ToggleValues[feature.Name] = value;

        if (value)
        {
            CheckParents(feature.ParentName);
        }
        else
        {
            UncheckChildren(feature.Name);
        }

        return Task.CompletedTask;
    }

    protected virtual void CheckParents(string parentName)
    {
        if (parentName.IsNullOrWhiteSpace())
        {
            return;
        }

        foreach (var featureGroupDto in Groups)
        {
            foreach (var featureDto in featureGroupDto.Features)
            {
                if (featureDto.Name == parentName && ToggleValues.ContainsKey(featureDto.Name))
                {
                    ToggleValues[featureDto.Name] = true;
                    CheckParents(featureDto.ParentName);
                }
            }
        }
    }

    protected virtual void UncheckChildren(string featureName)
    {
        foreach (var featureGroupDto in Groups)
        {
            foreach (var featureDto in featureGroupDto.Features)
            {
                if (featureDto.ParentName == featureName && ToggleValues.ContainsKey(featureDto.Name))
                {
                    ToggleValues[featureDto.Name] = false;
                    UncheckChildren(featureDto.Name);
                }
            }
        }
    }

    protected virtual IStringLocalizer CreateStringLocalizer(string resourceName)
    {
        return StringLocalizerFactory.CreateByResourceNameOrNull(resourceName) ??
               StringLocalizerFactory.CreateDefaultOrNull();
    }

    protected virtual async Task ClosingModal(MouseEventArgs eventArgs)
    {
        await CloseModal();
    }
}

