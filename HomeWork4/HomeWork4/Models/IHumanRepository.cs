using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    interface IHumanRepository
    {
        void DeleteHuman(int humanId);
        // IEnumerable<Human> GetAllHumans();
    }
}
