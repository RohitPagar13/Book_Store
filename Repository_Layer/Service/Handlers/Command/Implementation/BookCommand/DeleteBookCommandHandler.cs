using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.BookCommand
{
    public class DeleteBookCommandHandler : ICommandHandler<int,BookEntity>
    {
        private readonly IBookCommandRL _bookCommandRL;

        public DeleteBookCommandHandler(IBookCommandRL bookCommandRL)
        {
            _bookCommandRL = bookCommandRL;
        }

        public async Task<BookEntity> HandleAsync(int command)
        {
            try
            {
                return await _bookCommandRL.DeleteBookAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
