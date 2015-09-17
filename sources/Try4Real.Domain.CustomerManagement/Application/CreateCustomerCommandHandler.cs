using Try4Real.Domain.CustomerManagement.Application.Base;
using Try4Real.Domain.CustomerManagement.Domain;
using Try4Real.Domain.CustomerManagement.Infrastructure;

namespace Try4Real.Domain.CustomerManagement.Application
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(CreateCustomerCommand command)
        {
            var customer = new Customer(command.FirstName, command.LastName, command.BirthDate);
            customer.ChangeEmail(command.Email);
            _customerRepository.Add(customer);
        }
    }
}
