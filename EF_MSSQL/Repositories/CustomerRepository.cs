using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EF_MSSQL.Repositories;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<List<Customer>> GetAllAsync()
        => await context.Customers.AsNoTracking().ToListAsync();

    public async Task<Customer?> GetByIdAsync(Guid id)
        => await context.Customers.FindAsync(id);
    

    public async Task<Customer?> GetByEmailAsync(string email)
        => await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
    
    public async Task AddAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}