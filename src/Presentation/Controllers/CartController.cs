using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructure.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController()
    {
        _cartService = new CartService();
    }

    [HttpPost("add")]
    public IActionResult AddItem(string product, decimal price, int quantity)
    {
        _cartService.AddItem(new CartItem(product, price, quantity));
        return Ok($"Added {product} to cart.");
    }

    [HttpPost("remove")]
    public IActionResult RemoveItem(string product)
    {
        _cartService.RemoveItem(product);
        return Ok($"Removed {product} from cart.");
    }

    [HttpPost("undo")]
    public IActionResult Undo()
    {
        _cartService.Undo();
        return Ok("Undo performed.");
    }

    [HttpGet("show")]
    public IActionResult ShowCart()
    {
        _cartService.ShowCart();
        return Ok("Cart displayed in console.");
    }
}
