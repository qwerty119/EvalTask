using System;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using EvalTask.Domain.Entities;
using EvalTask.Dto.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public CreateCategoryCommand(CreateCategoryDto createCategoryDto, UserContext userContext)
        {
            CreateCategoryDto = createCategoryDto;
            UserContext = userContext;
        }

        private CreateCategoryDto CreateCategoryDto { get; }
        private UserContext UserContext { get; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
        {
            private readonly EvalTaskContext _context;

            public CreateCategoryCommandHandler(EvalTaskContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var newCategory = new Category(request.CreateCategoryDto.Name, request.CreateCategoryDto.Description,
                    request.UserContext.Id.ToString())
                {
                    Id = Guid.NewGuid(),

                };
                await _context.AddAsync(newCategory, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return newCategory.Id;
            }
        }
    }
}