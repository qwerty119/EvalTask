using System;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Categories;
using EvalTask.Dto.Products;
using MediatR;

namespace EvalTask.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public CreateProductCommand(CreateProductDto createProductDto, UserContext userContext)
        {
            CreateProductDto = createProductDto;
            UserContext = userContext;
        }

        private CreateProductDto CreateProductDto { get; }
        private UserContext UserContext { get; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly EvalTaskContext _context;

            public CreateProductCommandHandler(EvalTaskContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var newProduct = new Product(request.CreateProductDto.Name, request.CreateProductDto.CategoryId,
                    request.UserContext.Id.ToString())
                {
                    Id = Guid.NewGuid(),
                    Description = request.CreateProductDto.Description,
                    Specification = request.CreateProductDto.Specification

                };
                await _context.AddAsync(newProduct, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return newProduct.Id;
            }
        }
    }
}