using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EvalTask.Data;
using EvalTask.Domain.Specs;
using EvalTask.Dto.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public class
            GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
        {
            private readonly EvalTaskContext _context;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(EvalTaskContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Product
                    .Where(ProductSpec.NotDeleted())
                    .Include(x => x.Creator)
                    .Include(x => x.Changer)
                    .Include(x => x.Category)
                    .ToListAsync(cancellationToken: cancellationToken);
                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
        }
    }
}