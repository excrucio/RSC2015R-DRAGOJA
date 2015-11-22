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
    class NewMecProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<MecDTO, NewMecDTO>().ReverseMap();
        }
    }
}
