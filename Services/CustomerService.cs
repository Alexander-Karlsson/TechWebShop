using Entities;
using Services.Interfaces;

namespace Services;

public class CustomerService(ICustomerRepository customerRepo) : ICustomerService
{
    public async Task<List<Customer>> GetAllAsync() => await customerRepo.GetAllAsync();

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        var customer = await customerRepo.GetByIdAsync(id);
        if (customer is null)
            throw new KeyNotFoundException($"Customer with id: {id} was not found.");

        return customer;
    }

    public async Task AddAsync(Customer customer) => await customerRepo.AddAsync(customer);

    public async Task UpdateAsync(Customer customer) => await customerRepo.UpdateAsync(customer);

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await customerRepo.GetByIdAsync(id);
        if(customer is null)
            throw new KeyNotFoundException($"Customer with id: {id} was not found.");

        return await customerRepo.DeleteAsync(id);
    }
}