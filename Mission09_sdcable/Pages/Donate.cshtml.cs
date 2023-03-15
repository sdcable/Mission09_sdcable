using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_sdcable.Models;
using Mission09_sdcable.Infrastructure;

namespace Mission09_sdcable.Pages
{
    public class DonateModel : PageModel
    {
        private iBookStoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnURL { get; set; }
        public DonateModel(iBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            basket.AddItem(p, 1);

            return RedirectToPage(new { ReturnURL = returnUrl});
        }

        public IActionResult OnPostRemove(int bookId, string returnURL)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
