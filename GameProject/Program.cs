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
            //for test phase: initialize game & player
            GameController gameController = new GameController(4);
            Player player = new Player();

            //for test phase: setup player squad & 1st enemysquad (default parameter = level 1)
            gameController.CreatePlayerSquad(player);
            Squad enemySquad = gameController.CreateEnemySquad(2);
            Console.WriteLine(player.PlayerSquad.ToString());
            Console.WriteLine(enemySquad.ToString());
            Console.WriteLine("---------------------Squads ready!------------------------------\n");


            // for test phase:  remove 1st tooper and add medic
            player.PlayerSquad[0].UnAssign(player.PlayerSquad);
            Medic medic1 = new Medic("Doc");
            medic1.AssignToSquad(player.PlayerSquad);


            //initizalize battle
            BattleController b1 = new BattleController(player.PlayerSquad, enemySquad);
            bool playerWon = b1.RunBattle();
            Console.WriteLine(playerWon? "Well done. You whooped some alien ass!" : "Your squad has been defeated. Come back strong and show them who's boss!");
           

            //end
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
