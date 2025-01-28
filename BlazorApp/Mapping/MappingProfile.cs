using AutoMapper;
using _26_01_25.DTOs.Category;
using _26_01_25.DTOs.Product;
using _26_01_25.DTOs.Supplier;
using _26_01_25.Entities._Category;
using _26_01_25.Entities._Other;
using _26_01_25.Entities._Product;

namespace _26_01_25.Mapping
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

            // Маппинг _ProductConfigs -> ProductDto (Обычное отображение карточки товара на клиенте)
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier));


            
            CreateMap<CreateProductDto, Product>(); // Маппинг CreateProductDto -> _ProductConfigs  
    
            CreateMap<UpdateProductDto, Product>();  // Маппинг _ProductConfigs <-> UpdateProductDto //При попытке сохранить обновленный продукт

            //При открытии окна редактирования продукта, мы преобразуем ProductDto в UpdateProductDto и делаем это с помощью дозагрузку данных через контроллер
            //В контроллере по id из ProductDto мы получаем _ProductConfigs и преобразуем в UpdateProductDto
            CreateMap<Product, UpdateProductDto>();


            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Маппинг _Supplier <-> SupplierDto
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

        }
    }
}
