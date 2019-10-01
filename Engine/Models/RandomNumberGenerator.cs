using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public static class RandomNumberGenerator
    {
        private static readonly Random _randomNumber = new Random();

        public static int NumberBetween (int minValue, int maxValue)
        {
            return _randomNumber.Next(minValue, maxValue + 1);
        }
    }
}
