using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquadGameLib;

namespace UnitTests
{
    [TestClass]
    public class CreateSquadTest
    {
        [TestMethod]
        public void DefaultSquadCreationTest()
        {
            Player player = new Player();
            GameController gameController = new GameController(4, player);

            gameController.CreateSquad(SquadGameLib.Enums.Faction.EarthForces);

            Squad enemySquad = gameController.CreateSquad(SquadGameLib.Enums.Faction.Aliens);

            Assert.AreEqual(gameController.PlayerSquadSize, player.PlayerSquad.Count);
            Assert.AreEqual(gameController.PlayerSquadSize, player.PlayerSquad.Count);

        }
    }

}
