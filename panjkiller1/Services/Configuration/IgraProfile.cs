using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DTO;
using System.Threading.Tasks;
using AutoMapper;

namespace Services.Configuration
{
    class IgraProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Igra, IgraDTO>().ReverseMap();
        }
    }
}
