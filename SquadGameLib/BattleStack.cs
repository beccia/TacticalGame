using SquadGameLib.Controller;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class BattleStack : List<Unit>
    {


        public BattleStack()
        {
        }

        public BattleStack(List<Unit> units)
        {
            List<Unit> orderedBySpeed = units.OrderBy(u => u.Speed).ToList();
            orderedBySpeed.Reverse();
        }

        public void ExecuteRound()
        {
            bool unitSpeedChanged = false;

            foreach (Unit u in this)
            {
                if (u.Hp <= 0)
                {
                    continue;
                }
                
                //get & execute action

                if (unitSpeedChanged)
                {
                    this.OrderBy(c => c.Speed);
                }
            }
        }

    }
}
