using SquadGameLib.units;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Factory
{
    public class EarthArmySoldierFactory : ISoldierFactory<Unit>
    {

        public Unit Create() {
            return new Trooper();
        }

        public Unit CreateBasicSoldier()
        {
            return new Trooper();
        }

        public Unit CreateHeavySoldier()
        {
            return new HeavyGunner();
        }

        public Unit CreateMedicSoldier()
        {
            return new Medic();
        }

        public Unit CreateScout()
        {
            return new Sniper();
        }

        public Unit CreateTechSoldier()
        {
            return new SpecialOps();
        }
    }
}
