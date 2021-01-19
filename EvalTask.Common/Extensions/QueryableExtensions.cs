using System;
using System.Linq;
using System.Linq.Expressions;

namespace EvalTask.Common.Extensions
{

    public static class QueryableExtensions
    {

        public static IQueryable<T> PipeWhen<T>(this IQueryable<T> query, bool condition,
            Expression<Func<T, bool>> filter)
            => condition ? query.Where(filter) : query;

    }

}