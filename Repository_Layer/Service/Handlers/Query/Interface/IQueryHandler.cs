using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Interface
{
    public interface IQueryHandler<TCommand, TResponse>
    {
        Task<TResponse> HandleAsync(TCommand command);
    }
}
