using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mission09_sdcable.Models;

namespace Mission09_sdcable.Models
{
    public class Basket
    {
        //Declare and instantiate Items
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>(); //BasketLineItem instantiation/setting

        public virtual void AddItem (Book boo, int qty) //Adding a new item to the list
        {
            BasketLineItem Line = Items
                .Where(p => p.Book.BookId == boo.BookId)
                .FirstOrDefault();

            if (Line == null) //If no line, do this
            {
                Items.Add(new BasketLineItem
                {
                    Book = boo,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book boo)
        {
            Items.RemoveAll(x => x.Book.BookId == boo.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal() //Calculate the total price of all the stuff
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class BasketLineItem //Instance these.
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
