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
        public int RemainingTime { get; set; }

        public Dead(Unit affected)
        {
            this.RemainingTime = 3;
            this.Affected = affected;
        }

        public void Effect()
        {
            this.RemainingTime++;
        }

        public void Undo()
        {
            this.Affected.StatusEffects.Clear(this);
            this.Affected = null;
        }
    }
}
