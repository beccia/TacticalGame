using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class Barrage : Ability
    {
        private const string description = "Deal multiple attacks spread over the entire enemy squad.";
        private const int defaultCooldownTime = 4;

        public Barrage() : this(false)
        {
        }

        public Barrage(bool isPreferred) : base("Barrage", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} uses {this.Name} and unleashes heavy fire on {target.Assigned.Name}'s positions:");
            int attacks = GetNumberOfAttacks();
            for (int i = 0; i < attacks; i++)
            {
                List<Unit> availableTargets = target.Assigned.GetViableTargets();
                actor.Attack(availableTargets[GetRandomIndex(availableTargets.Count())]);
            }
            this.CooldownCount = this.CooldownTime;
        }

        public int GetNumberOfAttacks()
        {
            int result = 0;
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            switch (rgn)
            {
                case int n when (n < 15):
                    result = 2;
                    break;
                case int n when (n >= 15 && n < 45):
                    result = 3;
                    break;
                case int n when (n >= 45 && n < 70):
                    result = 4;
                    break;
                case int n when (n >= 70 && n <= 89):
                    result = 5;
                    break;
                case int n when (n >= 90):
                    result = 6;
                    break;
            }
            return result;
        }

        public int GetRandomIndex(int listLength)
        {
            int result = 0;
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, listLength);
            return result;
        }
    }
}
