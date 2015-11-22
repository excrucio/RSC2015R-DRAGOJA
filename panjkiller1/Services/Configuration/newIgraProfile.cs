using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Core;

namespace Services.Configuration
{
    public class newIgraProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IgraDTO, newIgraDTO>().ReverseMap();
        }
    }
}
