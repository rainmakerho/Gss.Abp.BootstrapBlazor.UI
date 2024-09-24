using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;

namespace Gss.Abp.SettingManagement.Blazor;
public class SettingManagementBlazorAutoMapperProfile : Profile
{
    public SettingManagementBlazorAutoMapperProfile()
    {
        //CreateMap<EmailSettingGroupViewComponent.UpdateEmailSettingsViewModel, UpdateEmailSettingsDto>();
        //CreateMap<EmailSettingsDto, EmailSettingGroupViewComponent.UpdateEmailSettingsViewModel>();

        //CreateMap<EmailSettingGroupViewComponent.SendTestEmailViewModel, SendTestEmailInput>();
    }
}
