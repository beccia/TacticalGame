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

        public ISoldierFactory<Unit> CreateFactory(ISoldierFactory<Unit> factory)
        {
            this.Factory = factory;
            return factory;
        }

        public static FactoryDirector GetInstanceOf()
        {
            if (_FactoryDirector != null)
            {
                return _FactoryDirector;
            } 
            else
            {
                return new FactoryDirector();
            }
        }
    }
}
