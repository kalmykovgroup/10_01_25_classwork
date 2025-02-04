using Application.CommandsAndQueries.DTOs.OrderDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsAndQueries.Commands.OrderSpace.OrderItemCommands
{
    public class CreateOrderItemCommand : IRequest<OrderItemDto>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public CreateOrderItemCommand(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
        {
            public CreateOrderItemCommandValidator()
            {
                RuleFor(x => x.OrderId).NotEmpty();
                RuleFor(x => x.ProductId).NotEmpty();
                RuleFor(x => x.Quantity).GreaterThan(0);
            }
        }
    }
}
