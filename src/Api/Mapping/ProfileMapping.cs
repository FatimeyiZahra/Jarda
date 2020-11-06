using Api.Resources;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mapping
{
    public class ProfileMapping : Profile
    {
        private static string BaseUrl = "https://localhost:44355/img/";

        public ProfileMapping()
        {
            CreateMap<Discount, DiscountResource>();

            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>()
               .ForMember(d => d.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => BaseUrl + p.Photo).ToArray()))
               .ForMember(r => r.ProductTags, opt => opt.MapFrom(src => src.ProductTags
                                                                        .Select(s => s.Tag.Name)
                                                                        .ToList()))
              .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Stocks.FirstOrDefault().Price))
              .ForMember(d => d.Discount, opt => opt.MapFrom(src => src.Discounts.FirstOrDefault().Discount));
              //.ForMember(c => c.Category, opt => opt.MapFrom(src => src.Category));


        }

    }
}
