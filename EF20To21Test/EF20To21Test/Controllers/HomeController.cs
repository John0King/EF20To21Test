using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF20To21Test.Models;
using EF20To21Test.Data;

namespace EF20To21Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            if (!_db.News.Any())
            {
                var newslist = Enumerable.Range(1, 100).Select(i => new News
                {
                    Title = $"Title{i}",
                    Content = $"Content{i}",
                    AddTime = DateTimeOffset.Now.AddDays(-i),
                    UpdateTime = DateTime.Now.AddDays(-i).AddHours(1),
                    //Id = i
                });
                _db.AddRange(newslist);
                await _db.SaveChangesAsync();

                var newsXlist = newslist.Select(i => new NewsX
                {
                    Title = $"Title{i.Id}",
                    NewsId = i.Id,
                    //Id = i
                });
            }

            // query is in view
            return View(_db.News);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Test2()
        {
            var news = _db.News.OrderByDescending(n => n.Id);
            return View(news);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
