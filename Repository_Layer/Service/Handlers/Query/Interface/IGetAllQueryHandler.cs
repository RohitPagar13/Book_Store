using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repository_Layer.Service.Handlers.Query.Interface
{
    public interface IGetAllQueryHandler<TResponse>
    {
        Task<TResponse> HandleAsync();
    }
}
