using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    public class HumanRepository : IHumanRepository
    {
        private InfestationDBContext _context { get; }

        public HumanRepository(InfestationDBContext context)
        {
            _context = context;
        }

        public void DeleteHuman(int humanId)
        {
            _context.Humans.Remove(_context.Humans.First(human => human.Id == humanId));
            _context.SaveChanges();
        }
    }
}
