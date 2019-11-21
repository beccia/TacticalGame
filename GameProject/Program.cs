using SquadGameLib;
using SquadGameLib.Controller;
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
            GameController gameController = new GameController(4);
            Player player = new Player();

            gameController.CreatePlayerSquad(player);
            Squad enemySquad = gameController.CreateEnemySquad();
            Console.WriteLine(player.PlayerSquad.ToString());
            Console.WriteLine(enemySquad.ToString());

            BattleController b1 = new BattleController(player.PlayerSquad, enemySquad);
           // bool playerWOn = b1.RunBattle();
           




            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
