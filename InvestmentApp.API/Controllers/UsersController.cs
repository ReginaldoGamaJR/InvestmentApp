using InvestmentApp.Application.DTOs.Requests;
using InvestmentApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentApp.API.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class UsersController : ControllerBase
{
    private readonly IRegisterUserUseCase _registerUserUseCase;
    private readonly ILoginUserUseCase _loginUserUseCase;
    public UsersController(
        IRegisterUserUseCase registerUserUseCase,
        ILoginUserUseCase loginUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _loginUserUseCase = loginUserUseCase;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        try
        {
            var response = await _registerUserUseCase.ExecuteAsync(request);

            return Created(string.Empty, response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _loginUserUseCase.ExecuteAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
    }
}