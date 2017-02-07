using System;
using BowlingGameKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Assert = NUnit.Framework.Assert;

namespace BowlingGameTest
{
    [TestFixture]
    public class BownlingGameTest
    {
        private Game game;

        [SetUp]
        protected void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            game.Score().ShouldBe(0);
        }

        private void RollMany(int numRolls, int pins)
        {
            for (int index = 0; index < numRolls; index++)
            {
                game.Roll(pins);
            }
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            game.Score().ShouldBe(20);
        }

        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            game.Score().ShouldBe(16);
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            game.Score().ShouldBe(24);
        }

        [Test]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            game.Score().ShouldBe(300);
        }

        [TestCase(12, 10, ExpectedResult = 300)]
        [TestCase(20, 1, ExpectedResult = 20)]
        public int TestMany(int rolls, int pins)
        {
            RollMany(rolls, pins);
            return game.Score();
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        
    }
}
