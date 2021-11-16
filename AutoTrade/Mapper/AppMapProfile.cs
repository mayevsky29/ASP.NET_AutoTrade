using AutoMapper;
using AutoTrade.Models;
using Data.AutoTrade.Entities;
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

            CreateMap<ProductAddViewModel, ProductEntity>()
                .ForMember(x => x.Image, opt => opt.Ignore());

            CreateMap<ProductEntity, ProductItemViewModel>()
              .ForMember(x => x.Description, opt => opt.MapFrom(x => "Product Description"))
              .ForMember(x => x.Image, opt => opt.MapFrom(x => @"\images\" + x.Image))
              .ForMember(x => x.Category, opt => opt.MapFrom(x => "Accessories"))
              .ForMember(x => x.Quantity, opt => opt.MapFrom(x => 25))
              .ForMember(x => x.InventoryStatus, opt => opt.MapFrom(x => "INSTOCK"))
              .ForMember(x => x.Rating, opt => opt.MapFrom(x => 5));

            CreateMap<CartAddViewModel, CartEntity>();

            CreateMap<CartEntity, CartItemViewModel>()
               .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name))
               .ForMember(x => x.ProductImage, opt => opt.MapFrom(x => @"\images\" + x.Product.Image))
               .ForMember(x => x.ProductPrice, opt => opt.MapFrom(x => x.Product.Price));
        }
    }
}