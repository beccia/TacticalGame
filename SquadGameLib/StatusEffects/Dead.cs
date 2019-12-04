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
        public Unit Affected { get; set; }
        public int TurnsCount { get; set; }

        public Dead(Unit affcted)
        {
            this.Affected = affcted;
        }

        public void Effect()
        {
            throw new NotImplementedException();
        }

    }
}
