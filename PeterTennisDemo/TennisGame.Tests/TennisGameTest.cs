using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame.Library;

namespace TennisGame.Tests
{
    /// <summary>
    /// TennisGameTest 的摘要說明
    /// </summary>
    [TestClass]
    public class TennisGameTest
    {
        private Library.TennisGame _tennisGame = new Library.TennisGame();

        public TennisGameTest()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void love_all()
        {
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            this._tennisGame.FirstPlayerScore();
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            GivenFirstPlayerScoreTimes(2);
            ScoreShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            GivenFirstPlayerScoreTimes(3);
            ScoreShouldBe("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            this._tennisGame.SecondPlayerScore();
            ScoreShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Love_Thirty()
        {
            GivenSecondPlayerScoreTimes(2);
            ScoreShouldBe("Love Thirty");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenFirstPlayerScoreTimes(1);
            GivenSecondPlayerScoreTimes(1);
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenFirstPlayerScoreTimes(2);
            GivenSecondPlayerScoreTimes(2);
            ScoreShouldBe("Thirty All");
        }

        [TestMethod]
        public void Deuse_When_3_3()
        {
            GivenFirstPlayerScoreTimes(3);
            GivenSecondPlayerScoreTimes(3);
            ScoreShouldBe("Deuse");
        }

        [TestMethod]
        public void Deuse_When_4_4()
        {
            GivenFirstPlayerScoreTimes(4);
            GivenSecondPlayerScoreTimes(4);
            ScoreShouldBe("Deuse");
        }

        [TestMethod]
        public void FirstPlayer_Adv_When_4_3()
        {
            GivenFirstPlayerScoreTimes(4);
            GivenSecondPlayerScoreTimes(3);
            ScoreShouldBe("FirstPlayer Adv");
        }

        private void GivenSecondPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                this._tennisGame.SecondPlayerScore();
            }
        }

        private void GivenFirstPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                this._tennisGame.FirstPlayerScore();
            }
        }

        private void ScoreShouldBe(string expected)
        {
            // Act
            string score = this._tennisGame.Score();

            // Assert
            Assert.AreEqual(expected, score);
        }
    }
}
