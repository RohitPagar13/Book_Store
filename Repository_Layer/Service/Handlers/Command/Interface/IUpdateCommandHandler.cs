using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Interface
{
    public interface IUpdateCommandHandler<Tint, TCommand, TResponse>
    {
        Task<TResponse> HandleAsync(int Id, TCommand command);
    }
}
