using AutoMapper;
using BlazorApp.DTOs;
using BlazorApp.Entities;

namespace BlazorApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Маппинг Category <-> CategoryDto
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Маппинг Supplier <-> SupplierDto
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

            // Маппинг Product <-> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier));

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore()) // Игнорируем, если не требуется обратное маппирование категории
                .ForMember(dest => dest.Supplier, opt => opt.Ignore()); // Игнорируем, если не требуется обратное маппирование поставщика

        }
    }
}
