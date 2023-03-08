using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission09_sdcable.Models;

namespace Mission09_sdcable.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private iBookStoreRepository repo { get; set; }
        public CategoryViewComponent (iBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = RouteData?.Values["categoryType"];

            var cat = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cat);
        }
    }
}
