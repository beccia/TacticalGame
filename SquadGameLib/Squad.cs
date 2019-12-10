using SquadGameLib.Enums;
using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using SquadGameLib.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class Squad : List<Unit>
    {
        public String Name { get; private set; }

        public Strategy Strategy { get; set; }

        public Squad()
        {

        }

        public Squad(string name)
        {
            this.Name = name;
            this.Strategy = Strategy.Offensive;
        }

        public bool isDefeated()
        {
            bool result;
            int combatants = 0;
            foreach (Unit u in this)
            {
                if (!u.IsIncapacitated())
                {
                    combatants++;
                }
            }
            result = (combatants > 0)?  false : true;
            return result;
        }

        public List<Unit> GetViableTargets()
        {
            List<Unit> list = this.ToList<Unit>();
            var result = list.Where(unit => !unit.IsIncapacitated());
            return result.ToList<Unit>();
        }

        public List<Unit> GetDownedUnits()
        {
            List<Unit> list = this.ToList<Unit>();
            var result = list.Where(unit => unit.StatusEffects.OfType<Down>().Any());
            return result.ToList<Unit>();
        }

        public void EndOfRoundActions()
        {
            ExecuteSupportActions();
            HandleCounters();
            Console.WriteLine($"\nStatus report:\n");
            foreach (Unit u in this)
            {
                u.StatusEffects.ExecuteEffects();
            }
            Console.WriteLine(this.isDefeated()? "\nSquad down!" : $"\n{this.Name} is ready for the next round.");
            Console.WriteLine("-----------------------------------------");
        }

        public void ExecuteSupportActions()
        {
            List<IHealer> supportUnits = new List<IHealer>();
            foreach (Unit u in this)
            {
                if (u is IHealer && !u.IsIncapacitated())
                {
                    supportUnits.Add((IHealer)u);
                }
            }
            if (supportUnits.Count > 0)
            {
                Console.WriteLine("Squadmembers of " + this.Name + " are commencing their support actions in between the fighting.\n");
                foreach (IHealer healer in supportUnits)
                {
                    healer.Support();
                }
            }
        }

        public void HandleCounters()
        {
            foreach (Unit u in this)
            {
                u.Abilities.ReduceCooldownCounters();
                u.StatusEffects.DecreaseTurnCount();
            }
        }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Squadname: {Name}\nUnits: {this.Count}\n");
            int count = 1; 
            foreach (Unit u in this) {
                sb.Append($"\nUnit {count}: \n{u.ToString()}\n-----------------------------------------\n");
                count++;
            }
            return sb.ToString();
        }
    }
}
