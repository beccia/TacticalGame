﻿using SquadGameLib.Abilities;
using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Aliens
{
    public class BattleLord : Unit
    {
        private const string className = "Battle Lord";
        private int _previousHp;
        private int _hp; 
        public override int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                List<Unit> availableMinions = _minionGuards.FindAll(m => m.Hp > 0);
                if (availableMinions.Count > 0)
                {
                    _previousHp = _hp;
                    int damageDealt = _previousHp - value;
                    int damagePU = damageDealt / availableMinions.Count;
                    Console.WriteLine($"{this.Name}'s minions take the damage for him and lose {damagePU} Hp each!");
                    foreach (Unit minion in availableMinions.ToList())
                    {
                        minion.Hp -= damagePU;
                    }
                    foreach (Unit minion in MinionGuards.ToList())
                    {
                        if (minion.Hp <= 0)
                        {
                            MinionGuards.Remove(minion);
                        }
                    }
                    _hp = _previousHp;
                }
                else {
                    _hp = value < 0 ? 0 : value > MaxHp ? MaxHp : value;
                    if (_hp == 0)
                    {
                        this.Down();
                    }
                }
            }
        }

        private List<Unit> _minionGuards = new List<Unit>();
        public List<Unit> MinionGuards
        {
            get
            {
                return _minionGuards;
            }
            set
            {
                _minionGuards = value;
            }
        }

        public BattleLord() : this("")
        {

        }

        public BattleLord(string name)
        {

            this.ClassName = className;
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 1.17);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 0.91);
            this.Defence = (int)(BaseStats * 0.52);
            this.Aim = (int)(BaseStats * 0.88);
            this.Evasion = (int)(BaseStats / 2.4);
            this.Speed = (int)(BaseStats * 0.87);
            this.CritChance = BaseStats / 12;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();
            this.MinionGuards = new List<Unit>();

            this.AddAbility(new SummonMinions(true));
            this.AddAbility(new MinionShield(true));
            this.AddAbility(new BattleCommand(true));
        }


        public override void TacticalAbility(Unit target)
        {
            if (this.Assigned.Strategy == Enums.Strategy.Survival)
            {
                List<Ability> abilities = this.Abilities.GetAvailableAbilities(Enums.AbilityType.Survival);
                foreach (Ability a in abilities)
                {
                    if (a.IsPreferred)
                    {
                        a.Use(this, target);
                        return;
                    }
                }
                abilities[0].Use(this, target);
            }
            else base.TacticalAbility(target);
        }
    }
}
