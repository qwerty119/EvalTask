using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvalTask.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Product.SQRS.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        public class
            GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entities.Product>>
        {
            private readonly EvalTaskContext _context;

            public GetAllProductsQueryHandler(EvalTaskContext context)
            {
                _context = context;
            }
            
            public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Product.ToListAsync();
            }
        }
    }
}