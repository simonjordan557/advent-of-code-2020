using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCodeHelper;

namespace Day3Library
{
    public class Toboggan
    {
        public int slopeX;
        public int slopeY;
        public List<string> mountain;

        public Toboggan()
        {
            mountain = new List<string>();
        }

        public Toboggan(int x, int y) : this()
        {
            slopeX = x;
            slopeY = y;  
        }

        public int HowManyTreeStrikes()
        {
            int treeStrikes = 0;
            int xPosition = 0;
            for (int i = 0; i < mountain.Count; i += slopeY)
            {
                if (mountain[i][xPosition % 31] == '#')
                {
                    treeStrikes++;
                }
                xPosition += slopeX;
            }
            return treeStrikes;
        }


    }
}
