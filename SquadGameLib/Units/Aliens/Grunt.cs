using SquadGameLib.Abilities;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Aliens
{
    public class Grunt : Unit
    {
        public Grunt(): base()
        {
            this.AddAbility(new Rush(true));
        }

     
    }
}
