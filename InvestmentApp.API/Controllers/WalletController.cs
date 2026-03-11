using InvestmentApp.Application.DTOs.Requests;
using InvestmentApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InvestmentApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class WalletsController : ControllerBase
{
    private readonly ICreateWalletUseCase _createWalletUseCase;

    public WalletsController(ICreateWalletUseCase createWalletUseCase)
    {
        _createWalletUseCase = createWalletUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWalletRequest request)
    {
        try
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized(new { Error = "Usuário não identificado no token." });
            }
            await _createWalletUseCase.ExecuteAsync(request, userId);

            return Created(string.Empty, new { Message = "Carteira criada com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}