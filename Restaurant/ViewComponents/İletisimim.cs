using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ViewComponents
{
    public class İletisimim : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public İletisimim(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var iletisim = _db.İletisimims.ToList();
            return View(iletisim);
        }
    }
}
