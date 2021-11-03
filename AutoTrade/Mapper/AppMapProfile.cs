using AutoMapper;
using AutoTrade.Models;
using Data.AutoTrade.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<RegisterViewModel, AppUser>()
                .ForMember(x => x.Photo, opt => opt.Ignore())
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));

            //    .ForMember(x => x.Photo, opt => opt.Ignore());
            //.ForMember(x => x.Image, opt => opt.MapFrom(x => "images/"
            //    + (string.IsNullOrEmpty(x.Photo) ? "noimage.jpg" : x.Photo)));
        }
    }
}