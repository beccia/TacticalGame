
using SquadGameLib.Enums;
using SquadGameLib.units;
using SquadGameLib.Units.Army;
using System.Collections.Generic;
using System.Linq;


namespace SquadGameLib.Controller
{
    public class BattleController
    {
        public Squad PlayerSquad { get; private set; }
        public Squad AiSquad { get; private set; }
        public BattleOrder BattleOrder { get; private set; }
        public int Round { get; private set; }
        public bool Ended { get; private set; }

        public delegate void DoAction(Unit target);

        public BattleController(Squad playerSquad, Squad enemySquad)
        {
            this.PlayerSquad = playerSquad;
            this.AiSquad = enemySquad;
            this.BattleOrder = new BattleOrder();
            this.Round = 1;
            this.Ended = false;
        }

        public bool RunBattle()
        {
            bool playerWon;

            do
            {
                BattleOrder = new BattleOrder(PlayerSquad, AiSquad);
                ExecuteRound(BattleOrder);
                Round++;
                if (PlayerSquad.isDefeated() || AiSquad.isDefeated())
                {
                    Ended = true;
                }
            } while (!Ended);
            playerWon = PlayerSquad.isDefeated() ? false : true;
            return playerWon;
        }

        
        public void ExecuteRound(BattleOrder CombatActions)
        {
            bool unitSpeedChanged = false;

            foreach (Unit u in CombatActions)
            {
                if (u.IsIncapacitated())
                {
                    continue;
                }

                //get & execute action
                Unit target;
                DoAction turnAction = DetermineAction(u, out target);

                turnAction.Invoke(target);


                if (unitSpeedChanged)
                {
                    CombatActions.SortbySpeed();
                }
            }
        }

        public DoAction DetermineAction(Unit unit, out Unit target)
        {
            DoAction result;
            switch (unit.Assigned.Strategy)
            {
                case Strategy.Offensive:
                    result = new DoAction(unit.Attack);
                    target = GetTarget(unit, Strategy.Offensive);
                    return result;
                case Strategy.StrongestFirst:
                    result = new DoAction(unit.Attack);
                    target = GetTarget(unit, Strategy.StrongestFirst);
                    return result;
                case Strategy.WeakestFirst:
                    result = new DoAction(unit.Attack);
                    target = GetTarget(unit, Strategy.WeakestFirst);
                    return result;
                case Strategy.Survival:
                    result = new DoAction(unit.Attack);
                    target = GetTarget(unit, Strategy.Survival);
                    return result;
                case Strategy.Tactical:
                    result = new DoAction(unit.TacticalAbility);
                    target = unit;
                    return result;
              
            }


            // default option for test 
            target = new Trooper();
            return new DoAction(unit.Attack);
        }


        public Unit GetTarget(Unit unit, Strategy strategy)
        {
            // select possible tagets 
            Squad enemySquad = AiSquad;
            if (unit.Assigned != PlayerSquad)
            {
                enemySquad = PlayerSquad;
            }
            Squad targettable = enemySquad.GetViableTargets();
            Unit target = null;

            switch (strategy)
            {
                case Strategy.Offensive:
                    int unitIndex = unit.Assigned.IndexOf(unit);
                    target = targettable[unitIndex];
                    // als leeg:

                    break;
                case Strategy.StrongestFirst:
                    break;
                case Strategy.WeakestFirst:
                    break;
                case Strategy.Survival:
                    break;
            }

       

            return target;
        }
    }
}
