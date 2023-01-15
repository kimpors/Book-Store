using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Book_Store.Models;
using Book_Store.Data;

namespace Book_Store.Controllers;

public class BookController : Controller
{
    private readonly BookDbContext _db;

    public BookController(BookDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View(_db.Books);
    }

    public IActionResult Login()
    {
        return View();
    }
}