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

        public int MaxHp { get; private set; }


        private int _hp;
        public int Hp {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value < 0 ? 0 : value > MaxHp ? MaxHp : value;
                if (_hp == 0)
                {
                    this.Die();
                }
            }
        
        }
        public int AttackPower { get; set; }
        public int Defence { get; set; }
        public int Aim { get; set; }
        public int Evasion { get; set; }
        public int Speed { get; set; }

        public Squad Assigned { get; private set; }

        public Status StatusEffects { get; private set; }
        public AbilityList Abilities { get; private set; }


        public Unit()
        {
            this.Name = "nameless";
            this.MaxHp = BaseStats;
            this.Hp = MaxHp;
            this.AttackPower = BaseStats;
            this.Defence = (int)(BaseStats * 0.7);
            this.Aim = BaseStats;
            this.Evasion = BaseStats / 2;
            this.Speed = BaseStats;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();
        }





        public virtual void Attack(Unit target)
        {
            Console.WriteLine(this.Name + " attacks "+ target.Name);
            if (!TargetHit(this.Aim, target.Evasion))
            {
                Console.WriteLine("The attack missed " + target.Name + ".");
                Console.WriteLine();
            }
            else
            {
                int totalDamage = (int)((this.AttackPower - target.Defence) * GetDamageModifyer(75, 120));
                Console.WriteLine("Hit target for " + totalDamage + " damage.");
                Console.WriteLine();
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

        public double GetDamageModifyer(int min, int max)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(min, max) / 100.00;
            return modifyer;
        }

        

        public void SpecialAttack(Unit target)
        {
            List<Ability> abilities = this.Abilities.GetAvailableAbilities(Enums.AbilityType.Offensive);
            abilities[0].Use(this, target);
        }

        public void TacticalAbility(Unit unit)
        {
            throw new NotImplementedException();

        }

        public void Die()
        {
            this.AddStatusEffect(new Dead(this));
            Console.WriteLine(this.Name + " has died");
        }

        public void Down()
        {
            this.AddStatusEffect(new Down(this));
            Console.WriteLine(this.Name + "is wounded and cannot fight anymore and will die without medical assitance soon.");
        }

        public void AddStatusEffect(IStatusEffect statusEffect)
        {
            this.StatusEffects.Add(statusEffect);
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
