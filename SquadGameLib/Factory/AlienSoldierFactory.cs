using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Factory
{
    public class AlienSoldierFactory : ISoldierFactory<ICombattable>
    {
        public ICombattable Create()
        {
            return new Grunt();
        }

        public ICombattable CreateBasicSoldier()
        {
            return new Grunt();
        }

        public ICombattable CreateHeavySoldier()
        {
            return new Annihilator();
        }

        public ICombattable CreateMedicSoldier()
        {
            return new Shaman();
        }

        public ICombattable CreateScout()
        {
            return new Striker();
        }

        public ICombattable CreateTechSoldier()
        {
            return new BattleLord();
        }
    }
}
