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

        

        public BattleOrder(Squad playerSquad, Squad enemySquad)
        {
            List<Unit> allUnits = new List<Unit>(playerSquad);
            allUnits.AddRange(enemySquad);
            List<Unit> sortedUnits = allUnits.OrderBy(u => u.Speed).ToList();
            sortedUnits.Reverse();
            this.AddRange(sortedUnits);
        }

    }
}
