namespace Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    
    // Lägg till längre fram
   // public ICollection<Order> Orders { get; private set; } = [];

    public Customer(Guid id, string firstName, string lastName, string email)
    {
        if(string.IsNullOrWhiteSpace(firstName) || firstName.Length < 2)
            throw new ArgumentException("First name cannot be empty and must contain at least 2 characters.", nameof(firstName));
        if(string.IsNullOrWhiteSpace(lastName) || lastName.Length < 1)
            throw new ArgumentException("Last name cannot be empty and must contain at least 1 character.", nameof(lastName));
        if(string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("A valid email address is required.", nameof(email));
        
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private Customer() { } // EF Core requirement
}