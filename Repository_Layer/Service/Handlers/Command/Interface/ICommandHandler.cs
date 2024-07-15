using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Interface
{
    public interface ICommandHandler<TCommand, TResponse>
    {
        Task<TResponse> HandleAsync(TCommand command);
    }
}
