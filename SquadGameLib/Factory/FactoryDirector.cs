using SquadGameLib.Enums;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Factory
{
    public class FactoryDirector
    {
        private static FactoryDirector _FactoryDirector;
        public ISoldierFactory<Unit> Factory { get;  private set; }

        private FactoryDirector()
        {

        }

        public ISoldierFactory<Unit> CreateFactory(Faction faction)
        {
            if (faction == Faction.EarthForces) {
                this.Factory = new EarthArmySoldierFactory();
            } 
            else
            {
                this.Factory = new AlienSoldierFactory();
            }
            return this.Factory;
        }

        public static FactoryDirector GetInstanceOf()
        {
            if (_FactoryDirector != null)
            {
                return _FactoryDirector;
            } 
            else
            {
                _FactoryDirector = new FactoryDirector();
                return _FactoryDirector;
            }
        }
    }
}
