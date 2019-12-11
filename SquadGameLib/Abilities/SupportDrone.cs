using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    /** SpecOps soldier tatcical ability: launches a drone which improves targeting & crit chance for squad. Default stats set in constructor
     */

    public class SupportDrone : Ability
    {
        private const string description = "Launches a drone which spots enemies for the squad, raising both aim and critical hit chance stats.";
        private const int defaultCooldownTime = 4;
        public const int statusEffectsDuration = 3;
        public const int aimBuff = 21;
        public const int critChanceBuff = 14;

        
        public SupportDrone() : this(false)
        {}

        public SupportDrone(bool isPreferred) : base("Support Drone", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Tactical;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} launches a drone near {target.Name}'s position which spots enemies for the squad, allowing friendly units to hit tagets and score critical hits more easily.");
            foreach (Unit u in actor.Assigned.GetViableTargets())
            {
                u.AddStatusEffect(new AimUp(statusEffectsDuration, aimBuff));
                u.AddStatusEffect(new CritChanceUp(statusEffectsDuration, critChanceBuff));
            }
            actor.AddStatusEffect(new DroneInAir(actor, 3));
            this.CooldownCount = this.CooldownTime;
        }
    }
}
