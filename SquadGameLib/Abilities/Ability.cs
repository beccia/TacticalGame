using SquadGameLib.Enums;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public abstract class Ability
    {
        public string Name {get; set; }
        public string Description { get; set; }
        public int CooldownCount { get; set; }
        public int CooldownTime { get; set; }
        public AbilityType Type { get; set; }
        public bool IsPreferred { get; set; }

        public Ability() : this("Unnamed ability")
        { }

        public Ability(string name) 
        {
            this.Name = name;
            this.CooldownCount = 0;
        }

        public Ability(string name, int cooldownTime)
        {
            this.Name = name;
            this.CooldownTime = cooldownTime;
            this.CooldownCount = 0;
        }

        public void ReduceCooldownTimer()
        {
            if (CooldownCount > 0)
            {
                this.CooldownCount--;
            }
        }

        public virtual void Use(Unit actor, Unit target)
        {
            Console.WriteLine("Abstract class ability used by " + actor.Name + "on " + target.Name);
        }

        public override string ToString()
        {
            return $"---------------\n* {this.Name}\nCooldown time: {this.CooldownTime}\nType: {this.Type.ToString()}\nDescription: {this.Description}";
        }
    }
}
