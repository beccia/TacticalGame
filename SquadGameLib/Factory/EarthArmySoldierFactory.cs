using SquadGameLib.units;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Factory
{
    public class EarthArmySoldierFactory : ISoldierFactory<ICombattable>
    {

        public ICombattable Create() {
            return new Trooper();
        }

        public ICombattable CreateBasicSoldier()
        {
            throw new NotImplementedException();
        }

        public ICombattable CreateHeavySoldier()
        {
            throw new NotImplementedException();
        }

        public ICombattable CreateMedicSoldier()
        {
            throw new NotImplementedException();
        }

        public ICombattable CreateScout()
        {
            throw new NotImplementedException();
        }

        public ICombattable CreateTechSoldier()
        {
            throw new NotImplementedException();
        }
    }
}
