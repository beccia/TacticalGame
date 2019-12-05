using SquadGameLib.Abilities;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Army
{
    public class SpecialOps : Unit
    {
        public bool DroneDeployed { get; set; }

        public SpecialOps() : base()
        {
            this.DroneDeployed = false;
            this.AddAbility(new SupportDrone(true));
        }
    }
}
