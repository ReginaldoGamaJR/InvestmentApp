namespace InvestmentApp.Application.DTOs.Requests;

public class RegisterUserRequest
{
    public string? Name { get; set; } 
    public string? Email { get; set; } 
    public string? Password { get; set; } 
    public string? PhoneNumber { get; set; } 
    public string? Street { get; set; }
    public string? City { get; set; } 
    public string? State { get; set; } 
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? Neighborhood { get; set; }
    public string? Number { get; set; }
}