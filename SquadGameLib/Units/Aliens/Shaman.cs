using SquadGameLib.Abilities;
using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Aliens
{
    /** Healing class of the Aliens. Can heal and revive uits, steals enemy HP on attack. Default stats set in contsructor.
     */
    public class Shaman : Unit, IHealer
    {
        public int MedSkills { get; set; }
        private int MinHealRoll { get; set; }
        private int MaxHealRoll { get; set; }
        private int ReviveChance { get; set; }
        public Shaman() : this("Nameless Shaman")
        {
        }

        public Shaman(string name)
        {
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 0.85);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 0.84);
            this.Defence = (int)(BaseStats * 0.62);
            this.Aim = (int)(BaseStats * 0.80);
            this.Evasion = (int)(BaseStats / 1.85);
            this.Speed = (int)(BaseStats * 0.96);
            this.CritChance = BaseStats / 18;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.MedSkills = 38;
            this.MinHealRoll = 70;
            this.MaxHealRoll = 126;
            this.ReviveChance= 60;

            this.AddAbility(new Leech(true)); ;
        }

        public override void Attack(Unit target)
        {
            int targetHpBeforeAttack = target.Hp;
            base.Attack(target);
            int targetHpAfterAttack = target.Hp;
            if (targetHpBeforeAttack != targetHpAfterAttack)
            {
                int damageDealt = targetHpBeforeAttack - targetHpAfterAttack;
                Console.WriteLine($"{this.Name} stole {damageDealt} HP from his target!");
                this.Hp += (targetHpBeforeAttack - targetHpAfterAttack);
            }
        }

        public void Heal(Unit target)
        {
            Console.WriteLine(this.Name + " uses his mysterious biological powers to heal his squad.");
            foreach (Unit u in this.Assigned.GetViableTargets())
            {
                if (u == this)
                {
                    continue;
                }
                else
                {
                    int healAmount = RollHealAmount();
                    u.Hp += healAmount;
                    Console.WriteLine($"{this.Name} is able to restore {healAmount} HP to {u.Name}.");
                }
            }
        }

        public void Support()
        {
            List<Unit> downed = this.Assigned.GetDownedUnits();
            if (downed.Any())
            {
                foreach (Unit u in downed)
                {
                    Console.WriteLine($"{this.Name} sends life energy towards {u.Name}.\n");
                    if (RollReviveChance())
                    {
                        int healAmount = RollHealAmount();
                        u.Hp += healAmount;
                        u.StatusEffects.Clear(new Down());
                        Console.WriteLine($"{this.Name} brings {u.Name} back with {u.Hp} HP.");
                    } 
                    else
                    {
                        Console.WriteLine($"But {u.Name} stays down.");
                    }
                }
            }

        }

        public int RollHealAmount()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(this.MinHealRoll, this.MaxHealRoll) / 100.00;
            int healAmount = (int)(modifyer * this.MedSkills);
            return healAmount;
        }

        public bool RollReviveChance()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            return this.ReviveChance > rgn ? true : false;
        }
    }
}