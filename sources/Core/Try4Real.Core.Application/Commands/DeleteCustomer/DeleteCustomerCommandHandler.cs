using Try4Real.Domain.User;
using Try4Realse.Core.Application.Commands.Base;

namespace Try4Realse.Core.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(DeleteCustomerCommand command)
        {
            _customerRepository.Delete(command.Id);
        }
    }
}
