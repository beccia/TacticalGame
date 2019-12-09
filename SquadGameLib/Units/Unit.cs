using SquadGameLib.Abilities;
using SquadGameLib.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.units
{
    public abstract class Unit
    {
        public readonly int BaseStats = 100;

        public string Name { get; set; }

        public int MaxHp { get; set; }


        private int _hp;
        public virtual int Hp {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value < 0 ? 0 : value > MaxHp ? MaxHp : value;
                if (_hp == 0)
                {
                    this.Down();
                }
            }
        
        }
        public int AttackPower { get; set; }
        public int Defence { get; set; }
        public int Aim { get; set; }
        public int Evasion { get; set; }
        public int Speed { get; set; }
        public int CritChance { get; set; }

        public Squad Assigned { get;  set; }

        public Status StatusEffects { get;  set; }
        public AbilityList Abilities { get;  set; }


        public Unit() : this ("Nameless")
        {
        }

        public Unit(string name)
        {
            this.Name = name;
            this.MaxHp = BaseStats;
            this.Hp = MaxHp;
            this.AttackPower = BaseStats;
            this.Defence = (int)(BaseStats * 0.7);
            this.Aim = BaseStats;
            this.Evasion = BaseStats / 2;
            this.Speed = BaseStats;
            this.CritChance = BaseStats / 12;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();
        }


        public virtual void Attack(Unit target)
        {
            Console.WriteLine($"\n{this.Name} attacks {target.Name}.");
            if (!TargetHit(this.Aim, target.Evasion))
            {
                Console.WriteLine("The attack missed " + target.Name + ".");
            }
            else
            {
                //normal attackrange = 80 min, 120 max 
                int totalDamage = (int)((this.AttackPower - target.Defence) * GetDamageModifyer(80, 120));
                totalDamage = totalDamage < 0 ? 0 : totalDamage;
                int criticalHitRollResult = CriticalHitDamage(totalDamage);
                if (criticalHitRollResult <= 0) {
                    Console.WriteLine("Hit target for " + totalDamage + " damage.");
                } else
                {
                    totalDamage = criticalHitRollResult;
                    Console.WriteLine($"{this.Name} lands a critical hit target for " + totalDamage + " damage!");
                }
                target.Hp -= totalDamage;
            }
        }
        
        public bool TargetHit(int aim, int evasion)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            // evasion modifyer 0.6 test and edit if needed 
            int statsResult = aim - (int)(evasion * 0.6);
            return statsResult > rgn ? true : false;
        }

        public int CriticalHitDamage(int normalDamage)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            if (this.CritChance > rgn ? true : false)
            {
                //range of critical hit: 128 min, 150 max
                return (int)(normalDamage * GetDamageModifyer(135, 155));
            } else
            {
                return 0;
            }

        }

        public double GetDamageModifyer(int min, int max)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(min, max) / 100.00;
            return modifyer;
        }



        public void SpecialAttack(Unit target)
        {
            List<Ability> abilities = this.Abilities.GetAvailableAbilities(Enums.AbilityType.Offensive);
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

        public virtual void TacticalAbility(Unit target)
        {
            List<Ability> abilities = this.Abilities.GetAvailableAbilities(Enums.AbilityType.Tactical);
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


        public void Die()
        {
            this.StatusEffects.ClearAll();
            this.AddStatusEffect(new Dead(this));
            Console.WriteLine(this.Name + " has died \n");
        }

        public void Down()
        {
            this.StatusEffects.ClearAll();
            this.AddStatusEffect(new Down(this));
            Console.WriteLine(this.Name + " is down and cannot fight anymore.\n");
        }

        public void AddStatusEffect(IStatusEffect statusEffect)
        {
            this.StatusEffects.Add(statusEffect);
            if (statusEffect.Affected == null)
            {
                statusEffect.Affected = this;
            }
        }

        public void AddAbility(Ability ability)
        {
            this.Abilities.Add(ability);
        }




        public bool IsIncapacitated()
        {
            if (this.StatusEffects.OfType<Dead>().Any() || this.StatusEffects.OfType<Down>().Any())
            {
                return true;
            }
            else return false;
        }

        public void AssignToSquad(Squad squad)
        {
            squad.Add(this);
            this.Assigned = squad;
        }

        public void UnAssign(Squad squad)
        {
            squad.Remove(this);
            this.Assigned = null;
        }
    }

}
