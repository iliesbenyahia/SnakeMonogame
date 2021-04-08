using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeV1
{
    class snake
    {
        private bool isAlive; 
        private int length; //longueur du serpent sans compter la tête
        private GraphicsDeviceManager _graphics;
        public List<snakePart> bodyParts;
        private Texture2D _headTexture, _bodyTexture;
        public String direction;
        public snake(int xStartPos, int yStartPos, GraphicsDeviceManager gd, Texture2D head, Texture2D body)
        {
            bodyParts = new List<snakePart>();
            _graphics = gd;
            _headTexture = head;
            _bodyTexture = body;
            length = 0;
            direction = "down";
            bodyParts.Add(new snakePart(direction, direction, xStartPos, yStartPos)); //première instance pour la tête du serpent
            bodyParts[0].isNew = false;
        }

        public void move()
        {
            for (int i=0; i<bodyParts.Count; i++)
            {
                bodyParts[i].move();      
            }
            if (bodyParts[0].reachedTarget)
            {
                bodyParts[bodyParts.Count - 1].isNew = false;
                for (int i = bodyParts.Count-1; i > 0; i = i - 1)
                {
                    bodyParts[i].currentDirection = bodyParts[i].futureDirection;
                    bodyParts[i].futureDirection = bodyParts[i-1].currentDirection;
                }
            }
   


        }

        public void grow()
        {
            int xNewPos = bodyParts[bodyParts.Count - 1].xPosition;
            int yNewPos = bodyParts[bodyParts.Count - 1].yPosition;
            bodyParts.Add(new snakePart(bodyParts[bodyParts.Count - 1].currentDirection, bodyParts[bodyParts.Count - 1].currentDirection, xNewPos, yNewPos));
        }
    }
}
