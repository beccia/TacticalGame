using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class CoveringFire : Ability
    {
        private const string description = "Lays down heavy machine gun covering fire for the squad, lowering offensive capabilities of the enemy squad for a few turns.";
        private const int defaultCooldownTime = 2;
        public const int statusEffectsDuration = 2;
        public const int successChance = 77;
        public const int aimDebuff = 29;
        public const int critChanceDebuff = 6;
        public const int attackDebuff = 9;


        public CoveringFire() : this(false)
        { }

        public CoveringFire(bool isPreferred) : base("Covering Fire", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Tactical;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} uses {this.Name} and lays down heavy covering fire for his squad.");
            foreach (Unit u in target.Assigned.GetViableTargets())
            {
                if (EnemySuppressed()) {
                    u.AddStatusEffect(new Suppressed(u, statusEffectsDuration, aimDebuff, attackDebuff, critChanceDebuff));
                }
            }
            this.CooldownTime = this.CooldownTime;
        }

        private bool EnemySuppressed()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            return successChance > rgn ? true : false;
        }

    }
}
