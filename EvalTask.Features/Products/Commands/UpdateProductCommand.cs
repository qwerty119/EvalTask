using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using EvalTask.Domain.Specs;
using EvalTask.Dto.Categories;
using EvalTask.Dto.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public UpdateProductDto UpdateProductDto { get; }
        public UserContext UserContext { get; }

        public UpdateProductCommand(Guid id, UpdateProductDto updateProductDto, UserContext userContext)
        {
            Id = id;
            UpdateProductDto = updateProductDto;
            UserContext = userContext;
        }
        
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
        {
            private readonly EvalTaskContext _context;

            public UpdateProductCommandHandler(EvalTaskContext context)
            {
                _context = context;
            }
            
            public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Product
                    .Where(ProductSpec.ById(request.Id) && ProductSpec.NotDeleted())
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (product == null)
                    return false;

                product.UpdatedByUserId = request.UserContext.Id.ToString();
                product.UpdatedDate = DateTime.Now;
                product.Name = request.UpdateProductDto.Name;
                product.Description = request.UpdateProductDto.Description;
                product.Specification = request.UpdateProductDto.Specification;
                _context.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}