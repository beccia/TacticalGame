using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class SummonMinions : Ability
    {
        private int SuccessChance { get; set; }
        private int Chain { get; set; }

       
        public SummonMinions() : this(false)
        {
            this.IsPreferred = false;
            this.Chain = 0;
            this.Type = Enums.AbilityType.Tactical;
        }

        //2nd argument is default cooldown Time
        public SummonMinions(bool isPreferred) : base("Summon minions", 3)
        {
            this.IsPreferred = isPreferred;
            this.SuccessChance = 72;
            this.Type = Enums.AbilityType.Tactical;
        }

        public SummonMinions(bool isPreferred, int initialCooldownTime) : base("Summon minions", 3)
        {
            this.IsPreferred = isPreferred;
            this.SuccessChance = 72;
            this.CooldownCount = initialCooldownTime;
            this.Type = Enums.AbilityType.Tactical;
        }

        public override void Use(Unit actor, Unit target)
        {
            int minionCount = 1;
            Console.WriteLine($"\n{actor.Name} uses {this.Name} and cries out to summon his loyal minions.");
            for (int i = 0; i < 4; i++)
            {
                Unit minion = SummonSucceeded() ? new Grunt($"{actor.Name}'s minion nr {minionCount}") : null;
                if (minion != null)
                {
                    Console.WriteLine($"A new alien Grunt joins the battle at {actor.Name}'s side!");
                    minion.AssignToSquad(actor.Assigned);
                    minionCount++;
                    Chain++;
                }
            }
            minionCount = 0;
            Chain = 0;
            this.CooldownCount = this.CooldownTime;
        }

        private bool SummonSucceeded()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            return this.SuccessChance - (Chain * 17) > rgn ? true : false;
        }
    }
}
