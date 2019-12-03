
using SquadGameLib.Enums;
using SquadGameLib.units;
using SquadGameLib.Units;
using SquadGameLib.Units.Army;
using System;
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
                Console.WriteLine("Starting round " + Round);
                Console.WriteLine();

                Console.WriteLine("Set stratgy for the next round using the numbered keys");
                Console.Write(" Offensive = 1, \n Tactical = 2, \n Survival = 3, \n StrongestFirst = 4, \n WeakestFirst =5");
                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine()) - 1;
                PlayerSquad.Strategy = (Strategy)choice;

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
                if (PlayerSquad.isDefeated() || AiSquad.isDefeated())
                {
                    Console.WriteLine("No targets left.");
                    return;
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
            Console.WriteLine("Ended round " + Round + ".");
            PlayerSquad.ExecuteSupportActions();
            AiSquad.ExecuteSupportActions();
            Console.WriteLine("-------------------------------------");
            


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
                    if (unit is IHealer)
                    {
                        IHealer healer = unit as IHealer;
                        result = new DoAction(healer.Heal);
                        target = GetTarget(unit, Strategy.Survival);
                        return result;
                        // else if has defensive special ability?
                    } else {
                        result = new DoAction(unit.Attack);
                        target = GetTarget(unit, Strategy.Offensive);
                        return result;
                    }
                case Strategy.Tactical:
                    result = new DoAction(unit.TacticalAbility);
                    target = unit;
                    return result;
                default:
                    target = null;
                    return new DoAction(unit.Attack);
            }
        }


        public Unit GetTarget(Unit unit, Strategy strategy)
        {
            Squad enemySquad = AiSquad;
            if (unit.Assigned != PlayerSquad)
            {
                enemySquad = PlayerSquad;
            }
            List<Unit> targettable = enemySquad.GetViableTargets();
            Unit target = null;

            switch (strategy)
            {
                case Strategy.Offensive:
                    int unitIndex = unit.Assigned.IndexOf(unit);
                    if (targettable.Count -1 >= unitIndex)
                    {
                        target = targettable[unitIndex];
                    }
                    else
                    {
                        do
                        {
                            unitIndex--;
                        } while (unitIndex > targettable.Count - 1);
                        target = targettable[unitIndex];
                    }

                    return target;
                case Strategy.StrongestFirst:
                    break;
                case Strategy.WeakestFirst:
                    break;
                case Strategy.Survival:



                    target = unit;
                    break;
            }

       

            return target;
        }
    }
}
