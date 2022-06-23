using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ViewComponents
{
    public class Comments:ViewComponent
    {
        private readonly ApplicationDbContext _db;
    
        public Comments(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            /*var comment = _db.Blogs.ToList();*///yönetici onayı olmadan tüm yorumları blog sayfasında gösterir!

            var comment = _db.Blogs.Where(i => i.Onay).ToList(); //sadece onaylı yorumlar listedim

            return View(comment);
        }
    }
}
