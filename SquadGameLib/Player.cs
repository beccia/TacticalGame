using SquadGameLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class Player
    {
        public string Name { get; private set; }
        public Faction Faction { get; private set; }
        public Squad PlayerSquad { get; set; }
        public int Level { get; set; }

        public Player() : this("Player 1", Faction.EarthForces, new Squad("Player's squad"))
        {
        }

        public Player(string name, Faction faction, Squad playerSquad)
        {
            this.Level = 1;
            this.Name = name;
            this.Faction = faction;
            this.PlayerSquad = playerSquad;
        }

    }
}
