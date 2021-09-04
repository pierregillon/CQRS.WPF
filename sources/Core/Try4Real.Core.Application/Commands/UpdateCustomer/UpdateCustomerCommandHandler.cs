using Try4Real.Domain.User;
using Try4Realse.Core.Application.Commands._Base;

namespace Try4Realse.Core.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository) => _customerRepository = customerRepository;

        public void Handle(UpdateCustomerCommand command)
        {
            var customer = _customerRepository.GetBy(command.Id);

            customer.Rename(command.FirstName, command.LastName);
            customer.ChangeEmail(command.Email);
            customer.BirthDate = command.BirthDate;

            _customerRepository.Update(customer);
        }
    }
}