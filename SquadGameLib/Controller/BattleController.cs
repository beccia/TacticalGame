
using SquadGameLib.Enums;
using SquadGameLib.units;
using SquadGameLib.Units;
using SquadGameLib.Units.Aliens;
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
            Console.WriteLine($"Starting Battle against {AiSquad.Name}");
            Console.WriteLine();
            do
            {
                BattleOrder = new BattleOrder(PlayerSquad, AiSquad);

                Console.WriteLine($"\nSet stratgy for round nr {Round} using the numbered keys: ");
                Console.Write(" 1 = Offensive , \n 2 = Tactical, \n 3 = Survival \n 4 =  StrongestFirst, \n 5 = WeakestFirst");
                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine()) - 1;
                PlayerSquad.Strategy = (Strategy)choice;

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Battle round {Round}:");
                Console.WriteLine("-----------------------------------------------\n");

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

            foreach (Unit u in CombatActions.ToList())
            {
                if (u.IsIncapacitated())
                {
                    CombatActions.Remove(u);
                    continue;
                }
                if (PlayerSquad.isDefeated() || AiSquad.isDefeated())
                {
                    Console.WriteLine("No targets left.");
                    return;
                }
                Unit target;
                DoAction turnAction = DetermineAction(u, out target);
                turnAction.Invoke(target);
                CombatActions.Remove(u);

                if (unitSpeedChanged)
                {
                    CombatActions = (BattleOrder)CombatActions.OrderBy(u => u.Speed).ToList();
                }
            }
            Console.WriteLine("\nEnded fighting of round " + Round + ".");
            Console.WriteLine("-------------------------------------");
   

            PlayerSquad.EndOfRoundActions();
            AiSquad.EndOfRoundActions();
        }

        public DoAction DetermineAction(Unit unit, out Unit target)
        {
            DoAction result;
            switch (unit.Assigned.Strategy)
            {
                case Strategy.Offensive:

                    if (unit.Abilities.GetAvailableAbilities(AbilityType.Offensive).Count > 0)
                    {
                        result = new DoAction(unit.SpecialAttack);
                        target = GetTarget(unit, Strategy.Offensive);
                        return result;
                    }
                    else
                    {
                        result = new DoAction(unit.Attack);
                        target = GetTarget(unit, Strategy.Offensive);
                        return result;
                    }
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
                    if (unit.Abilities.GetAvailableAbilities(AbilityType.Tactical).Count > 0 || unit.GetType() == typeof(Medic))
                    {
                        result = new DoAction(unit.TacticalAbility);
                        target = GetTarget(unit, Strategy.Tactical);
                        return result;
                    }
                    else
                    {
                        result = new DoAction(unit.Attack);
                        target = GetTarget(unit, Strategy.Tactical);
                        return result;
                    }
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
                case Strategy.Tactical:
                    foreach (Unit u in targettable)
                    {
                        if (u.Hp <= unit.AttackPower - u.Defence)
                        {
                            target = u;
                            return target;
                        }
                    }
                    target = GetTarget(unit, Strategy.Offensive);
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
