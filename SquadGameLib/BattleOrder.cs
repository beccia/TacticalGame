using SquadGameLib.Controller;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class BattleOrder : List<Unit>
    {


        public BattleOrder()
        {
        }

        public BattleOrder(List<Unit> units)
        {
            List<Unit> orderedBySpeed = units.OrderBy(u => u.Speed).ToList();
            orderedBySpeed.Reverse();
        }



    }
}
