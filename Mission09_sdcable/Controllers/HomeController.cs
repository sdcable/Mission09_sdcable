using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_sdcable.Models;
using Mission09_sdcable.Models.ViewModels;

namespace Mission09_sdcable.Controllers
{
    public class HomeController : Controller
    {
        private iBookStoreRepository repo;

        public HomeController(iBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            int pageSize = 4; //Set page size to be 10 books long.

            var x = new BookViewModel //Creating a new big model that includes the Book model and PageInfo model.
            {
                Books = repo.Books //Creating Books
                .Where(p => p.Category == categoryType || categoryType == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo //Creating the PageInfo Model that will be passed to the view, which will then be passed to the TagHelper
                {
                    TotalNumBooks =
                    (
                        categoryType == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == categoryType).Count()
                    ),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
