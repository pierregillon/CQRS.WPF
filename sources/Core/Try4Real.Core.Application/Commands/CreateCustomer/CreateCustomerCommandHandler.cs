using Try4Real.Domain.User;
using Try4Realse.Core.Application.Commands.Base;

namespace Try4Realse.Core.Application.Commands.CreateCustomer
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
