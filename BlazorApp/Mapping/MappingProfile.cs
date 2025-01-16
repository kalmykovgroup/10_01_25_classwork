using AutoMapper;
using BlazorApp.DTOs.Category;
using BlazorApp.DTOs.Product;
using BlazorApp.DTOs.Supplier;
using BlazorApp.Entities;

namespace BlazorApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Для создании копии (Helpers/CloneHelper)
            CreateMap<CategoryDto, CategoryDto>().ReverseMap(); 
            CreateMap<SupplierDto, SupplierDto>().ReverseMap(); 
            CreateMap<ProductDto, ProductDto>().ReverseMap();
            CreateMap<UpdateProductDto, UpdateProductDto>().ReverseMap();

            // Маппинг Product -> ProductDto (Обычное отображение карточки товара на клиенте)
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier));


            
            CreateMap<CreateProductDto, Product>(); // Маппинг CreateProductDto -> Product  
    
            CreateMap<UpdateProductDto, Product>();  // Маппинг Product <-> UpdateProductDto //При попытке сохранить обновленный продукт

            //При открытии окна редактирования продукта, мы преобразуем ProductDto в UpdateProductDto и делаем это с помощью дозагрузку данных через контроллер
            //В контроллере по id из ProductDto мы получаем Product и преобразуем в UpdateProductDto
            CreateMap<Product, UpdateProductDto>();


            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Маппинг Supplier <-> SupplierDto
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

        }
    }
}
