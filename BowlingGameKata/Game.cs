using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BowlingGameKata
{
    public class Game
    {
        private int _scoreTotal = 0;
        private int[] _rolls = new int[21];
        private int _currentRole = 0;

        public void Roll(int pins)
        {
            _scoreTotal += pins;
            _rolls[_currentRole++] = pins;
        }

        public int Score()
        {
            _scoreTotal = 0;
            int frameIndex = 0;
            for(int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    _scoreTotal += 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    _scoreTotal += 10 + _rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    _scoreTotal += _rolls[frameIndex] + _rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return _scoreTotal;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}
