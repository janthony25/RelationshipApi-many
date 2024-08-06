using Microsoft.EntityFrameworkCore;
using RelationShip8_7.Data;
using RelationShip8_7.Models;
using RelationShip8_7.Models.Dto;

namespace RelationShip8_7.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCustomerCarAsync(AddCustomerWithCarDto customerDto)
        {
            var newCustomer = new Customer
            {
                CustomerName = customerDto.CustomerName
            };

            _dataContext.Customers.Add(newCustomer);
            await _dataContext.SaveChangesAsync();

            // Create Car
            var car = new Car
            {
                CarRego = customerDto.CarRego,
                CarModel = customerDto.CarModel,
                CustomerId = newCustomer.CustomerId
            };

            _dataContext.Cars.Add(car);
            await _dataContext.SaveChangesAsync();

            // FInd the make by Id
            var make = await _dataContext.Makes.FindAsync(customerDto.MakeId);
            if(make == null)
            {
                throw new KeyNotFoundException("Key not found");
            }

            // Create CarMake
            var carMake = new CarMake
            {
                CarId = car.CarId,
                MakeId = make.MakeId
            };

            // Add CarMake to Db
            _dataContext.CarMakes.Add(carMake);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<CustomerDto> GetCustomerCarByIdAsync(int id)
        {
            var customerCar = await _dataContext.Customers
                .Include(c => c.Car)
                    .ThenInclude(car => car.CarMake)
                        .ThenInclude(cm => cm.Make)
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Cars = c.Car.Select(car => new CarDto
                    {
                        CarId = car.CarId,
                        CarRego = car.CarRego,
                        CarModel = car.CarModel,
                        Make = car.CarMake.Select(cm => new MakeDto
                        {
                            MakeId = cm.Make.MakeId,
                            MakeName = cm.Make.MakeName
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();

            return customerCar;
        }

        public async Task<List<CustomerDto>> GetCustomerCarListAsync()
        {
            return await _dataContext.Customers
                .Include(c => c.Car)
                    .ThenInclude(car => car.CarMake)
                        .ThenInclude(cm => cm.Make)
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Cars = c.Car.Select(car => new CarDto
                    {
                        CarId = car.CarId,
                        CarRego = car.CarRego,
                        CarModel = car.CarModel,
                        Make = car.CarMake.Select(cm => new MakeDto
                        {
                            MakeId = cm.Make.MakeId,
                            MakeName = cm.Make.MakeName
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<List<CustomerDetailsDto>> GetCustomersAsync()
        {
            return await _dataContext.Customers
                .Select(c => new CustomerDetailsDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName
                }).ToListAsync();
        }
    }
}
