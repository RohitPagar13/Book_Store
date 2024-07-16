using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Interface
{
    public interface IQueryHandler<TQuery, TResponse>
    {
        Task<TResponse> HandleAsync(TQuery query);
    }
}
