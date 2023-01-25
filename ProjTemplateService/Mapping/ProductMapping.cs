using AutoMapper;
using ProjTemplateCommon.DTOs;
using ProjTemplateData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.CreatedDate , opts=> opts.Ignore())
                .ForMember(dest => dest.ModifiedDate, opts => opts.Ignore())
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opts => opts.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .AfterMap((src, dest) => dest.SetDefaultAudit());
                
            CreateMap<Product, ProductDTO>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ProductName, opts => opts.MapFrom(src => src.ProductName))
                    .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                    ;
        }
    }
}
