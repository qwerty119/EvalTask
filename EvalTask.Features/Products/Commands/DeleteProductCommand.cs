using System;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using MediatR;

namespace EvalTask.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public UserContext UserContext { get; }

        public DeleteProductCommand(Guid id, UserContext userContext)
        {
            Id = id;
            UserContext = userContext;
        }
        
        // TODO: убрать внутренний класс
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
        {
            private readonly EvalTaskContext _context;

            public DeleteProductCommandHandler(EvalTaskContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Product.FindAsync(request.Id);
                if (product == null)
                    return false;

                product.UpdatedByUserId = request.UserContext.Id.ToString();
                product.IsDeleted = true;
                product.UpdatedDate = DateTime.Now;

                _context.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}