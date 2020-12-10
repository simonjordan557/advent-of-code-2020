using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Library
{
    public class Toboggan
    {
        public int slopeX;
        public int slopeY;
        public List<string> mountain;

        public Toboggan()
        {
            mountain = new List<string>() { "hello" };
        }

        public Toboggan(int x, int y) : this()
        {
            slopeX = x;
            slopeY = y;  
        }


    }
}
