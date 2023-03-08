using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_sdcable.Models;

namespace Mission09_sdcable.Models
{
    public class Basket
    {
        //Declare and instantiate Items
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Book proj, int qty)
        {
            BasketLineItem Line = Items
                .Where(p => p.Book.BookId == proj.BookId)
                .FirstOrDefault();

            if (Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = proj,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
