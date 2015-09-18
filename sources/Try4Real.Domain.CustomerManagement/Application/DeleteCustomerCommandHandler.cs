using Try4Real.Domain.CustomerManagement.Application.Base;
using Try4Real.Domain.CustomerManagement.Infrastructure;

namespace Try4Real.Domain.CustomerManagement.Application
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
