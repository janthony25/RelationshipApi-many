using RelationShip8_7.Models.Dto;

namespace RelationShip8_7.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDetailsDto>> GetCustomersAsync();
        Task<List<CustomerDto>> GetCustomerCarListAsync();
        Task<CustomerDto> GetCustomerCarByIdAsync(int id);
        Task AddCustomerCarAsync(AddCustomerWithCarDto customer);
    }
}
