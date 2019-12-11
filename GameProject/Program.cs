using SquadGameLib;
using SquadGameLib.Controller;
using SquadGameLib.Enums;
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
            Player player = new Player();
         //TODO: prompt for name & Squad here 

            GameController gameController = new GameController(4, player);

            
            //player.PlayerSquad = gameController.CreateSquad(Faction.EarthForces, player.Level);
            gameController.PlayerChooseYourSquad();



            Squad enemySquad = gameController.CreateSquad(Faction.Aliens, player.Level);

            Console.WriteLine(player.PlayerSquad.ToString());
            Console.WriteLine(enemySquad.ToString());
            Console.WriteLine("---------------------Squads ready!------------------------------\n");



            //initizalize battle, insert enemy strategy array in BattleController constructor
            int[] basicAiPattern = new int[] { 0, 2, 0, 0, 2 };
            int[] tacticalAiPattern = new int[] { 1, 0, 2, 1, 0, 0, 2};
            int[] carefulAiPattern = new int[] { 1, 2, 0, 2, 1, 2, 0};

            BattleController b1 = new BattleController(player.PlayerSquad, enemySquad, tacticalAiPattern);

            bool playerWon = b1.RunBattle();
            Console.WriteLine(playerWon? "Well done. You whooped some alien ass!" : "Your squad has been defeated. Come back strong and show them who's boss!");
           

            //end
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
