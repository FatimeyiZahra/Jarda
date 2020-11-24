using Api.Resources;
using Api.Resources.User;
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
        private static string BaseUrl = "https://localhost:44394/img/";

        public ProfileMapping()
        {
            CreateMap<Discount, DiscountResource>();

            CreateMap<Category, CategoryResource>();
            CreateMap<Specification, SpecificationResource>();

            CreateMap<Product, ProductResource>()
               .ForMember(d => d.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => BaseUrl + p.Photo).ToArray()))
               .ForMember(r => r.ProductTags, opt => opt.MapFrom(src => src.ProductTags
                                                                        .Select(s => s.Tag.Name)
                                                                        .ToList()))
               .ForMember(r => r.ProductSpecifications, opt => opt.MapFrom(src => src.ProductSpecifications
                                                                        .Select(s => s.Specification.Name)
                                                                        .ToList()))
              .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Stocks.FirstOrDefault().Price))
              .ForMember(d => d.Discount, opt => opt.MapFrom(src => src.Discounts.FirstOrDefault().Discount));
            //.ForMember(c => c.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<NewsResource, NewsCategory>();
            //CreateMap<NewsCategory, NewsResource>();


            CreateMap<News, NewsResource>()
               .ForMember(d => d.Photos, opt => opt.MapFrom(src => src.NewsPhotos
                                                                            .Select(p => BaseUrl + p.Photo)
                                                                            .ToArray()))

              .ForMember(n => n.NewsCategories, opt => opt.MapFrom(src => src.NewsCategories
                                                                      .Select(s => s.Category.Name)
                                                                      .ToList()));

            CreateMap<RegisterResource, User>()
          .ForMember(d => d.Status, opt => opt.MapFrom(src => true))
          .ForMember(d => d.AddedDate, opt => opt.MapFrom(src => DateTime.Now))
          .ForMember(d => d.AddedBy, opt => opt.MapFrom(src => "System"))
          .ForMember(d => d.Password, opt => opt.MapFrom(src => CryptoHelper.Crypto.HashPassword(src.Password)))
          .ForMember(d => d.Token, opt => opt.MapFrom(src => CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString())));

            CreateMap<User, UserResource>()
                .ForMember(d => d.RegisterDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd.MM.yyyy")));

        }

    }
}
