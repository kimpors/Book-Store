using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Book_Store.Infrastructure;
using Book_Store.Models;
using Book_Store.Data;

namespace Book_Store.Controllers;

public class CartController : Controller
{
    private readonly BookDbContext _db;

    public CartController(BookDbContext db)
    {
        _db = db;
    }
    public IActionResult AddToCart(int id)
    {
        Book book = _db.Books
            .FirstOrDefault(p => p.Id == id);

        if (book != null)
        {
            Cart cart = GetCart();
            cart.AddItem(book, 1);
            SaveCart(cart);
        }

        return RedirectToAction("Index", "Book");
    }

    public ViewResult Index()
    {
        return View(GetCart());
    }

    public IActionResult RemoveFromCart(int id)
    {
        Book book = _db.Books
            .FirstOrDefault(p => p.Id == id);

        if (book != null)
        {
            Cart cart = GetCart();
            cart.RemoveLine(book);
            SaveCart(cart);
        }

        return RedirectToAction("Index");
    }

    private Cart GetCart()
    {
        Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        return cart;
    }

    private void SaveCart(Cart cart)
    {
        HttpContext.Session.SetJson("Cart", cart);
    }

}