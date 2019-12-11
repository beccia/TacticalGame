using SquadGameLib.StatusEffects.Buffs;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class MistScreen : Ability
    {
        private const string description = "Grants a defence boost to entire squad by covering them with a mist that decreases bullet velocity";
        private const int defaultCooldownTime = 4;
        public const int statusEffectsDuration = 3;
        public const int DefenceBuff = 16;


        public MistScreen() : this(false)
        { }

        public MistScreen(bool isPreferred) : base("Mist Screen", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Tactical;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} uses {target.Name} and a layer of mist covers his squad, which slightly slows down incoming bullets.");
            foreach (Unit u in actor.Assigned.GetViableTargets())
            {
                u.AddStatusEffect(new DefenceUp(statusEffectsDuration, DefenceBuff));
            }
            this.CooldownCount = this.CooldownTime;
        }
    }
}
