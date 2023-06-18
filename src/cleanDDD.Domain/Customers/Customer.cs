using System;

namespace cleanDDD.Domain.Customers;

public class Customer
{
    public Guid Id { get; private set; }

    public string? Email { get; private set; }
    public string? Name { get; private set; }

    // Use a private constructor to enforce use of the factory method
    private Customer(string email, string name)
    {
        ValidateAndSetEmail(email);
        ValidateAndSetName(name);

        Id = Guid.NewGuid();
    }

    // Factory Method to create a new customer
    public static Customer Create(string email, string name)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Email and name must not be null or empty.");
        }

        return new Customer(email, name);
    }

    // Method to update email
    public void UpdateEmail(string newEmail)
    {
        ValidateAndSetEmail(newEmail);
    }

    // Method to update name
    public void UpdateName(string newName)
    {
        ValidateAndSetName(newName);
    }

    private void ValidateAndSetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
        {
            throw new ArgumentException("Invalid email address.", nameof(email));
        }
        Email = email;
    }

    private void ValidateAndSetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        }
        Name = name;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(email);
            return mailAddress.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
