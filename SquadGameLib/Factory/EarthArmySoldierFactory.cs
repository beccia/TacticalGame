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
            throw new NotImplementedException();
        }

        public Unit CreateHeavySoldier()
        {
            throw new NotImplementedException();
        }

        public Unit CreateMedicSoldier()
        {
            throw new NotImplementedException();
        }

        public Unit CreateScout()
        {
            throw new NotImplementedException();
        }

        public Unit CreateTechSoldier()
        {
            throw new NotImplementedException();
        }
    }
}
