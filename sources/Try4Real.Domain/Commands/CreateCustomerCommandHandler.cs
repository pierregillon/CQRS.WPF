using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Commands
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
