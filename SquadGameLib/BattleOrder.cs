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

        //public BattleOrder(List<Unit> units)
        //{
        //    List<Unit> orderedBySpeed = units.OrderBy(u => u.Speed).ToList();
        //    orderedBySpeed.Reverse();
        //}

        public BattleOrder(Squad playerSquad, Squad enemySquad)
        {
            List<Unit> allUnits = new List<Unit>(playerSquad);
            allUnits.AddRange(enemySquad);
            AddRange(allUnits);
            SortbySpeed();
        }
        
        public void SortbySpeed()
        {
            this.OrderBy(u => u.Speed).ToList();
            Reverse();
        }

    }
}
