using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeV1
{
    class snakePart
    {
        private string currentDirection;
        private string futureDirection;

        public snakePart(string currentDirection, string futureDirection)
        {
            this.currentDirection = currentDirection;
            this.futureDirection = currentDirection;
        }
    }
}
