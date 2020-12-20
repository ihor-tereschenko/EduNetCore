using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork3.Models;

namespace HomeWork3.Controllers
{
    public class NewsController: Controller
    {
        public IActionResult Index()
        {
            ViewBag.news = new List<string> { 
                "Humanity finally colonized the Mercury!!",
                "Increase your lifespan by 10 years, every morning you need...",
                "Scientists estimed the time of the vaccine invension: it is a summer of 2021",
                "Ukraine reduces the cost of its obligations!",
                "A species were discovered in Africa: it is blue legless cat"
            };
            return View();
        }

        public IActionResult Show (int id)
        {
            ViewData["news"] = NewsBase.News.First(news => news.Id == id).Title;
            return View();
        }
    }
}
