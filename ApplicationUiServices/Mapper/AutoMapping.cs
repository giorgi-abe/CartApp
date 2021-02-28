using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUiServices.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<>().ReverseMap();
        }
    }
}
