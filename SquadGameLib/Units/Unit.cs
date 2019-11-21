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
        public const int BaseStats = 100;

        public string Name { get; set; }

        public int MaxHp { get; private set; }
        public int Hp { get; set; }
        public int AttackPower { get; private set; }
        public int Defence { get; private set; }
        public int Aim { get; private set; }
        public int Evasion { get; private set; }
        public int Speed { get; private set; }

        public Squad Assigned { get; private set; }

        public Status StatusEffects { get; private set; }
        //TODO: ABility, Status effect


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
        }





        public void Attack(Unit target)
        {
            Console.WriteLine(this.Name + " attacks "+ target.Name);
            if (!TargetHit(this.Aim, target.Evasion))
            {
                Console.WriteLine("The attack missed " + target.Name + ".");
                Console.WriteLine();
            }
            else
            {
                Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                double modifyer = rd.Next(75, 120)/100.00;
                int statsDamage = this.AttackPower - target.Defence;
                int totalDamage = (int)(statsDamage * modifyer);
                Console.WriteLine("Hit target for " + totalDamage + " damage.");
                Console.WriteLine();
                target.Hp -= totalDamage;
            }
            if (target.Hp <= 0) //nog toevoegen: down
            {
                target.Hp = 0;
                target.Die();
            }

        }

        public bool TargetHit(int aim, int evasion)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            int statsResult = aim - (int)(evasion * 0.6);
            return statsResult > rgn ? true : false;
        }

        public void Die()
        {
            this.AddStatusEffect(new Dead(this));
            Console.WriteLine(this.Name + " has died");
        }

        public void Down()
        {
            //chosen for 4 as turncount so 3 full truns remain
            Down down = new Down(this, 4);
            this.AddStatusEffect(down);
            Console.WriteLine(this.Name + "is wounded and cannot fight anymore. Needs medical assistance within " + down.CountLimit + "turns." );
        }

        public void SpecialAttack(Unit unit)
        {
            throw new NotImplementedException();
        }

        public void TacticalAbility(Unit unit)
        {
            throw new NotImplementedException();

        }

        public void AddStatusEffect(IStatusEffect statusEffect)
        {
            this.StatusEffects.Add(statusEffect);
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
    }

}
