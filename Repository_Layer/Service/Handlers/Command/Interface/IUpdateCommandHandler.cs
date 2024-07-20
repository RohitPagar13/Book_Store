using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Interface
{
    public interface IUpdateCommandHandler<TCommand1, TCommand2, TResponse>
    {
        Task<TResponse> HandleAsync(TCommand1 command1, TCommand2 command2);
    }
}
