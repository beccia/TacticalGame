
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Controller
{
    public class BattleController
    {
        public Squad PlayerSquad { get; private set; }
        public Squad AiSquad { get; private set; }
        public BattleOrder CombatActions { get; private set; }
        public int Round { get; private set; }
        public bool Ended { get; private set; }

        public delegate void DoAction();

        public BattleController(Squad playerSquad, Squad enemySquad)
        {
            this.PlayerSquad = playerSquad;
            this.AiSquad = enemySquad;
            this.CombatActions = new BattleOrder();
            this.Round = 1;
            this.Ended = false;
        }

        public BattleOrder SetActions()
        {
            List<Unit> allUnits = new List<Unit>(PlayerSquad);
            allUnits.AddRange(AiSquad);
            BattleOrder result = new BattleOrder(allUnits);
            return result;
        }

        public bool RunBattle()
        {
            bool playerWon;

            do
            {
                CombatActions = SetActions();
                ExecuteRound(CombatActions);
                Round++;
                if (PlayerSquad.Count == 0 || AiSquad.Count == 0)
                {
                    Ended = true;
                }
            } while (!Ended);
            playerWon = PlayerSquad.Count == 0 ? false : true;
            return playerWon;
        }

        
        public void ExecuteRound(BattleOrder CombatActions)
        {
            bool unitSpeedChanged = false;

            foreach (Unit u in CombatActions)
            {
                if (u.Hp <= 0)
                {
                    continue;
                }

                //get & execute action
                
                DoAction turnAction = DetermineAction(u);
                turnAction.Invoke();


                if (unitSpeedChanged)
                {
                    CombatActions.OrderBy(c => c.Speed);
                }
            }
        }

        public DoAction DetermineAction(Unit unit)
        {


            // default option for test 
            return new DoAction(unit.Attack);
        }



    }
}
