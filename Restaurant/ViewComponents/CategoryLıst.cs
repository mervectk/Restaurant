using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ViewComponents
{
    public class CategoryLıst: ViewComponent //using için ctrl. bas //KALITIM ALDIRDIM
    {
        //veritabanına bağlanma işlemleri
        private readonly ApplicationDbContext _db;
        public CategoryLıst(ApplicationDbContext db) //yapıcı metot ctor tab tab yap
        {
            _db = db;

        }
        public IViewComponentResult Invoke()

        //Invoke bir IViewComponentResultdöndüren zaman uyumlu yöntem.
        //invoke=çağırmak
        {
            var category = _db.Categories.ToList();
            return View(category);
        }
    }
}
