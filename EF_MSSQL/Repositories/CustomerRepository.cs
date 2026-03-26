using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EF_MSSQL.Repositories;

public class CustomerRepository(AppDbContext db) : ICustomerRepository
{
    public async Task<List<Customer>> GetAllAsync()
        => await db.Customers.AsNoTracking().ToListAsync();

    public async Task<Customer?> GetByIdAsync(Guid id)
        => await db.Customers.FindAsync(id);
    
    public async Task<Customer?> GetByEmailAsync(string email)
        => await db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
    
    public async Task AddAsync(Customer customer)
    {
        await db.Customers.AddAsync(customer);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        db.Customers.Update(customer);
        await db.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await db.Customers.FindAsync(id);
        if (customer is null) return false;
        
        db.Customers.Remove(customer);
        await db.SaveChangesAsync();
        return true;
    }
}