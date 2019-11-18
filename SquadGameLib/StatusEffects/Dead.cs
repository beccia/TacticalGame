using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class Dead : IStatusEffect
    {
        public Unit Affcted { get; set; }
        public int TurnsCount { get; set; }
        public Unit Affected { get; set; }

        public void Effect()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
