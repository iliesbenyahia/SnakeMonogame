using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeV1
{
    class level
    {
        public int width, height; //unités de 1 bodyPart de Serpent
        public int xApplePos, yApplePos;
        public level(int lvlWidth, int lvlHeight)
        {
            
            Random rand = new Random();
            xApplePos = rand.Next(1, 10) *40;
            yApplePos = rand.Next(1, 10) *40;
        }
        public void update(snake Serpent)
        {
            if(Serpent.bodyParts[0].xPosition == xApplePos && Serpent.bodyParts[0].yPosition == yApplePos)
            {
                Random rand = new Random();
                xApplePos = rand.Next(1, 10) * 40;
                yApplePos = rand.Next(1, 10) * 40;
                Serpent.grow();
            }
        }
    }
}
