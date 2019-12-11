using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class Camouflage : Ability
    {
        private const string description = "Camouflages self to greatly increase evasion.";
        private const int defaultCooldownTime = 3;
        private int evasionBuff = 26;
        private const int statusEffectsDuration = 3;

        public Camouflage() : this(false)
        {
            this.IsPreferred = false;
            this.Type = Enums.AbilityType.Tactical;
        }


        public Camouflage(bool isPreferred) : base("Camouflage", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Tactical;
        }


        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} uses {this.Name} and is camouflashed, making it harder for {target.Assigned.Name} to hit him.");
            actor.AddStatusEffect(new EvasionUp(statusEffectsDuration, evasionBuff));
                this.CooldownCount = this.CooldownTime;
        }

    }
}
