namespace InvestmentApp.Application.DTOs.Requests;

public record RegisterUserRequest(
    string Name,
    string Email,
    string Password,
    string? PhoneNumber,
    string? Street,
    string? City,
    string? State,
    string? ZipCode,
    string? Country,
    string? AdditionalInfo,
    string? Neighborhood,
    string? Number
);