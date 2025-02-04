using Application.CommandsAndQueries;
using Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands;
using Application.CommandsAndQueries.Commands.ProductSpace.ProductCommands;
using Application.CommandsAndQueries.DTOs.OrderDTOs;
using Application.CommandsAndQueries.DTOs.ProductDTOs;
using Application.CommandsAndQueries.Queries.Product;
using AutoMapper;
using Domain.Entities._Order;
using Domain.Entities._Product; 

namespace Application.MappingProfiles.ProductMappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
             

            // 🔹 Маппинг между сущностью `Product` и `ProductDto`
            CreateMap<Product, ProductDto>();
            CreateMap<OrderItem, OrderItemDto>();

            // 🔹 DTO -> Commands (CQRS)
            CreateMap<CreateProductCommand, Product>(); 
            CreateMap<UpdateProductCommand, Product>(); 

            CreateMap<CreateOrderItemCommand, OrderItem>(); 
            CreateMap<UpdateOrderItemCommand, OrderItem>(); 

             
        }
    }
}
