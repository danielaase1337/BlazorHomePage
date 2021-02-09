using AutoMapper;
using BlazorHomepage.Shared.CovidHandlerData.Entities;
using BlazorHomepage.Shared.Model.CovidModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
