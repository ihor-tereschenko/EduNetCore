using Infestation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class HumanController : Controller
    {
        private InfestationDBContext _context;

        //private InfestationDBContext _context { get; }
        private IHumanRepository _humanRepository { get; }

        public HumanController(InfestationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var humans = _context.Humans.Where(human => human.Id == id || id == 0).ToList();
            ViewData["Humans"] = humans;

            return View();
        }
        public IActionResult Country (string name)
        {
            // var human = _context.Humans.Include(human => human.Country).First(human => human.Id == humanId);
            // var humans = _context.Humans.Where(human => human.CountryId == country.Id).First(country => country.Name == name);
            Country _country = _context.Countries.First(country => country.Name == name);
            var humans = _context.Humans.Where(human => human.CountryId == _country.Id).ToList();
            // ViewData["CountryName"] = human.Country.Name;
            ViewData["Humans"] = humans;
            return View();
        }
        public IActionResult DeleteHuman (int humanId)
        {
            try
            {
                _humanRepository.DeleteHuman(humanId);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            return View();
        }
    }
}
