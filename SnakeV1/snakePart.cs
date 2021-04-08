using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeV1
{
    class snakePart
    {
        public string currentDirection, futureDirection;
        public int xPosition, yPosition;
        public bool isNew;
        public bool reachedTarget;


        public snakePart(string currentDirection, string futureDirection, int xStartPos, int yStartPos)
        {
            this.currentDirection = currentDirection;
            this.futureDirection = currentDirection;
            this.xPosition = (xStartPos / 40) * 40;
            this.yPosition = (yStartPos / 40) * 40;
            isNew = true;
            reachedTarget = false;
        }

        public void move()
        {
            if (!isNew)
            {
                if (currentDirection == "up")
                {
                    yPosition -= 1;
                }
                if (currentDirection == "down")
                {
                    yPosition += 1;
                }
                if (currentDirection == "right")
                {
                    xPosition += 1;
                }
                if (currentDirection == "left")
                {
                    xPosition -= 1;
                }
                if (xPosition % 40 == 0 && yPosition % 40 == 0)
                {
                    reachedTarget = true;
                    currentDirection = futureDirection;
                }
                else
                {
                    reachedTarget = false;
                }
            }         
        }
    }
}
