using System;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using MediatR;

namespace EvalTask.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public UserContext UserContext { get; }

        public DeleteCategoryCommand(Guid id, UserContext userContext)
        {
            Id = id;
            UserContext = userContext;
        }
        
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
        {
            private readonly EvalTaskContext _context;

            public DeleteCategoryCommandHandler(EvalTaskContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Category.FindAsync(request.Id);
                if (category == null)
                    return false;

                category.UpdatedByUserId = request.UserContext.Id.ToString();
                category.IsDeleted = true;
                category.UpdatedDate = DateTime.Now;

                _context.Update(category);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}