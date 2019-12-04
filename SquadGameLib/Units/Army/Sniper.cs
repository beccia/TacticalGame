using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Army
{
    public class Sniper : Unit, IHardToHit
    {
        public Unit targetInSight { get; private set; }

        public Sniper() : base()
        {

        }

        public override void Attack(Unit target)
        {

        }

        public void Dodge()
        {
            throw new NotImplementedException();
        }
    }
}
