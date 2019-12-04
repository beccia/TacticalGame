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

        public Down()
        {

        }

        public Down(Unit affected)
        {
            this.Affected = affected;
        }

        public Down(Unit affected, int countLimit)
        {
            this.Affected = affected;
            this.CountLimit = countLimit;
        }

        public void Effect()
        {
            throw new NotImplementedException();
        }

    }
}
