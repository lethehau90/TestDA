using AutoMapper;
using DoAn.Model.Models;
using DoAn.Web.Models;

namespace DoAn.Web.Mappings
{
    public static class AutoMapperConfiguraion
    {
        public static void Configure()
        {
            Mapper.CreateMap<ControlPanel, ControlPanelViewModel>();
            Mapper.CreateMap<Donation, DonationViewModel>();
            Mapper.CreateMap<Laudatory, LaudatoryViewModel>();
            Mapper.CreateMap<CustomImage, CustomImageViewModel>();
        }
    }
}