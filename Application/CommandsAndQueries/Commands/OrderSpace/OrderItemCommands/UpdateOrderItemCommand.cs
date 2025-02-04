using Application.CommandsAndQueries.DTOs.OrderDTOs;
using Application.Interfaces; 
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands
{
    public class UpdateOrderItemCommand : IRequest<OrderItemDto>, IHaveKey<(Guid, Guid)>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public (Guid, Guid) Id => (OrderId, ProductId); // 🔹 Реализация IHaveKey

        public UpdateOrderItemCommand(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }


        public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
        {
            public UpdateOrderItemCommandValidator()
            {
                RuleFor(x => x.OrderId).NotEmpty();
                RuleFor(x => x.ProductId).NotEmpty();
                RuleFor(x => x.Quantity).GreaterThan(0);
            }
        }

    }
}
