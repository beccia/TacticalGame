using SquadGameLib;
using SquadGameLib.Controller;
using SquadGameLib.units;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize game & player
            GameController gameController = new GameController(4);
            Player player = new Player();

            //setup player squad & 1st enemysquad
            gameController.CreatePlayerSquad(player);
            Squad enemySquad = gameController.CreateEnemySquad();
            Console.WriteLine(player.PlayerSquad.ToString());
            Console.WriteLine(enemySquad.ToString());

            // remove 1st tooper and add medic
            player.PlayerSquad[0].UnAssign(player.PlayerSquad);
            new Medic().AssignToSquad(player.PlayerSquad);


            //initizalize battle
            BattleController b1 = new BattleController(player.PlayerSquad, enemySquad);
            bool playerWOn = b1.RunBattle();
            Console.WriteLine("Player won: " + playerWOn);
           




            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
