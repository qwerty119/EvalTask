using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EvalTask.Data;
using EvalTask.Dto.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvalTask.Features.Products.Queries
{
    // TODO: пересмотреть концепицию запроса
    public class GetProductByIdQuery :  IRequest<ProductDto>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
        
        public class
            GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
        {
            private readonly EvalTaskContext _context;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(EvalTaskContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Product.Where(x => x.Id == request.Id)
                    .Include(x => x.Creator)
                    .FirstAsync(cancellationToken: cancellationToken);
                return _mapper.Map<ProductDto>(products);
            }
        }
    }
}