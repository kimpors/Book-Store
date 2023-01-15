using System.Collections.Generic;
using System.Linq;

namespace Book_Store.Models;

public class Cart
{
    private List<CartLine> lineCollection = new List<CartLine>();

    public void AddItem(Book book, int quantity)
    {
        CartLine line = lineCollection
            .Where(p => p.Book.Id == book.Id)
            .FirstOrDefault();

        if (line == null)
        {
            lineCollection.Add(new CartLine
            {
                Book = book,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public void RemoveLine(Book book)
        => lineCollection.RemoveAll(l => l.Book.Id == book.Id);
    public decimal ComputeTotalValue()
        => lineCollection.Sum(u => u.Book.Price * u.Quantity);
    public void Clear() => lineCollection.Clear();
    public IEnumerable<CartLine> Lines => lineCollection;

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}