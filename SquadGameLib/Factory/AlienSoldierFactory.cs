using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Factory
{
    public class AlienSoldierFactory : ISoldierFactory<Unit>
    {
        public Unit Create()
        {
            return new Grunt();
        }

        public Unit CreateBasicSoldier()
        {
            return new Grunt();
        }

        public Unit CreateHeavySoldier()
        {
            return new Annihilator();
        }

        public Unit CreateMedicSoldier()
        {
            return new Shaman();
        }

        public Unit CreateScout()
        {
            return new Striker();
        }

        public Unit CreateTechSoldier()
        {
            return new BattleLord();
        }
    }
}
