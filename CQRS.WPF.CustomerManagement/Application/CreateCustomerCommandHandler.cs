using CQRS.WPF.CustomerManagement.Application.Base;
using CQRS.WPF.CustomerManagement.Domain;
using CQRS.WPF.CustomerManagement.Infrastructure;

namespace CQRS.WPF.CustomerManagement.Application
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
