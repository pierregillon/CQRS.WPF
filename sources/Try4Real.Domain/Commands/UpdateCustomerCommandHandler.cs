using Try4Real.Domain.Commands.Base;
using Try4Real.Domain.Model.User;

namespace Try4Real.Domain.Commands
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

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