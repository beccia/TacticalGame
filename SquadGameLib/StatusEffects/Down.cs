using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class Down : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int TurnsCount { get; set; }
       

        public int CountLimit { get; set; }

        public void Effect()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {

        }
    }
}
