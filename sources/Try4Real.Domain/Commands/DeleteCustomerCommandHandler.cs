using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Commands
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
