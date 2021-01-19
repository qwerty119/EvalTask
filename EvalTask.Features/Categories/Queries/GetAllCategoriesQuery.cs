using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EvalTask.Data;
using EvalTask.Domain.Specs;
using EvalTask.Dto.Categories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public class
            GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
        {
            private readonly EvalTaskContext _context;
            private readonly IMapper _mapper;

            public GetAllCategoriesQueryHandler(EvalTaskContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Category
                    .Where(CategorySpec.NotDeleted())
                    .Include(x => x.Creator)
                    .Include(x => x.Changer)
                    .ToListAsync(cancellationToken: cancellationToken);
                return _mapper.Map<IEnumerable<CategoryDto>>(products);
            }
        }
    }
}