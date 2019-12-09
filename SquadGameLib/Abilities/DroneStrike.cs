using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    /** Special attack usable by SpecialOps soldier after drone has been launched. Deal guaranteed damage to tactical target and 1 nearby unit
     */
    public class DroneStrike : Ability
    {

        public int BaseDamage { get; private set; }
        public int StatusEffectsDuration { get; private set; }

        //2nd argument is default cooldown Time
        public DroneStrike() : base("Drone strike", 4)
        {
            this.IsPreferred = false;
            this.BaseDamage = 71;
            this.Type = Enums.AbilityType.Offensive;
        }

        public DroneStrike(bool isPreferred) : base("Drone strike", 4)
        {
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            if (!((SpecialOps)actor).DroneDeployed)
            {
                Console.WriteLine($"{actor.Name} thinks a drone strike would be ideal, but drone hasn't been deployed.\n");
                actor.Attack(target);
            }
            else
            {

                Unit tacticalTarget = GetDroneStrikeTarget(target);
                int damage = GetPrimaryTargetDamage(tacticalTarget);

                Console.WriteLine($"{actor.Name} launches a missile strike from his drone on tactical target {tacticalTarget.Name}.");
                Console.WriteLine($"BOOM! {tacticalTarget.Name} takes {damage} damage. \n");

                tacticalTarget.Hp -= damage;
                DealSecondaryTargetDamage(tacticalTarget);
                this.CooldownCount = this.CooldownTime;
            }
        }


        public Unit GetDroneStrikeTarget(Unit target)
        {
            List<Unit> available =  target.Assigned.GetViableTargets();
            IEnumerable<Unit> topThreats = available.OfType<Striker>();
            Unit droneTarget = available.OfType<Striker>().Count() != 0 ? topThreats.First() : available.OfType<BattleLord>().Count() != 0 ? available.OfType<BattleLord>().First() :
                available.OfType<Shaman>().Count() != 0 ? available.OfType<Shaman>().First() : available.OfType<Annihilator>().Count() != 0 ? available.OfType<Annihilator>().First() : target;
            return droneTarget;
        }

        public int GetPrimaryTargetDamage(Unit target)
        {
            int statDamage = BaseDamage - (target.Defence / 3);
            int totalDamage = (int) (statDamage * target.GetDamageModifyer(85, 110));
            return totalDamage;
        }

        public void DealSecondaryTargetDamage(Unit target)
        { 
            List<Unit> availableTargets = target.Assigned.GetViableTargets();
            if (availableTargets.Count > 1)
            {
                int index = availableTargets.IndexOf(target);
                Unit secondaryTarget = (index - 1 >= 0) ? availableTargets[index - 1] : availableTargets[index + 1];
                int statDamage = (BaseDamage / 2) - (target.Defence / 3);
                int totalDamage = (int)(statDamage * target.GetDamageModifyer(85, 110));

                Console.WriteLine($"{secondaryTarget.Name} gets caught in the blast and takes {totalDamage} damage.");
                secondaryTarget.Hp -= totalDamage;
            }
        }



    }
}

