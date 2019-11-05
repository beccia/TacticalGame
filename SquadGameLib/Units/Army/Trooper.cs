using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Army
{
    public class Trooper : Unit, IHealer
    {
        public Trooper() : base()
        {
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }
    }
}
