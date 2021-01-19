using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using EvalTask.Domain.Specs;
using EvalTask.Dto.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public UpdateCategoryDto UpdateCategoryDto { get; }
        public UserContext UserContext { get; }

        public UpdateCategoryCommand(Guid id, UpdateCategoryDto updateCategoryDto, UserContext userContext)
        {
            Id = id;
            UpdateCategoryDto = updateCategoryDto;
            UserContext = userContext;
        }
        
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
        {
            private readonly EvalTaskContext _context;

            public UpdateCategoryCommandHandler(EvalTaskContext context)
            {
                _context = context;
            }
            
            public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Category
                    .Where(CategorySpec.ById(request.Id) && CategorySpec.NotDeleted())
                    .FirstOrDefaultAsync(cancellationToken);
                
                if (category == null)
                    return false;

                category.UpdatedByUserId = request.UserContext.Id.ToString();
                category.UpdatedDate = DateTime.Now;
                category.Name = request.UpdateCategoryDto.Name;
                category.Description = request.UpdateCategoryDto.Description;
                _context.Update(category);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}