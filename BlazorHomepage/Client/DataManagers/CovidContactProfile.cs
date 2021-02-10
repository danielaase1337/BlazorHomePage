using AutoMapper;
using BlazorHomepage.Shared.CovidHandlerData.Entities;
using BlazorHomepage.Shared.Model.CovidModels;

namespace BlazorHomepage.Client.DataManagers
{
    public class CovidContactProfile : Profile
    {
        public CovidContactProfile()
        {
            this.CreateMap<OneCovidContact, OneContactModel>();
        }
    }
}
