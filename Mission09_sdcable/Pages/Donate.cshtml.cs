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

        public DonateModel(iBookStoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnURL { get; set; }
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(p, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnURL = returnUrl});
        }
    }
}
