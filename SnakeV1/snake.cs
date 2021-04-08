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
        }

        public void move()
        {
            for(int i=0; i<bodyParts.Count; i++)
            {
                bodyParts[i].move();
            }
        }
    }
}
