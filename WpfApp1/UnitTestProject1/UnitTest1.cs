using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseWork;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public PlayerContext player_db = new PlayerContext();
        public GameContext game_db = new GameContext();
        public StadiumContext stadium_db = new StadiumContext();

        [TestMethod]
        public void PlayerContext()
        {
            List<Player> list = new List<Player>();
            list = player_db.Deserialize();
           foreach(var i in list)
            {
                Assert.IsTrue(i.GetFirstName() != "");
            }
        }
        [TestMethod]
        public void GameContext()
        {
            List<Game> list = new List<Game>();
            list = game_db.Deserialize();
            foreach (var i in list)
            {
                Assert.IsTrue(i.GetCoutOfVisitors() != "");
            }
        }
        [TestMethod]
        public void StadiumContext()
        {
            List<Stadium> list = new List<Stadium>();
            list = stadium_db.Deserialize();
            foreach (var i in list)
            {
                Assert.IsTrue(i.GetName() != "");
            }
        }
    }
}
