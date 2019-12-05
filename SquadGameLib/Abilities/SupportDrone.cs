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
        public int StatusEffectsDuration { get; private set; }
        public int AimBuff { get; private set; }
        public int CritChanceBuff { get; private set; }

        
        public SupportDrone() : this(false)
        {}

        //2nd argument is default cooldown Time
        public SupportDrone(bool isPreferred) : base("Support drone", 4)
        {
            this.IsPreferred = isPreferred;
            this.StatusEffectsDuration = 3;
            this.AimBuff = 21;
            this.CritChanceBuff = 11;
            this.Type = Enums.AbilityType.Tactical;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} launches a drone near {target.Name}'s position which spots enemies for the squad, allowing friendly units to hit tagets and score critical hits more easily");
            foreach (Unit u in actor.Assigned.GetViableTargets())
            {
                u.AddStatusEffect(new AimUp(u, StatusEffectsDuration, AimBuff));
                u.AddStatusEffect(new CritChanceUp(u, StatusEffectsDuration, CritChanceBuff));
            }
            actor.AddStatusEffect(new DroneInAir(actor, 3));
        }

    }
}
