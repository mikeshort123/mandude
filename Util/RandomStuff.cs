using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Util
{
    class RandomStuff
    {
        static Random rand = new Random();

        public static float GetFloat(float min, float max) 
        {
            return ((max - min) * (float)rand.NextDouble()) + min;
        }

        public static int GetInt(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
