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
        public int xPos, yPos;
        private GraphicsDeviceManager _graphics;
        private List<snakePart> bodyParts;
        private Texture2D _headTexture, _bodyTexture;
        private String direction;
        public snake(int xStartPos, int yStartPos, GraphicsDeviceManager gd, Texture2D head, Texture2D body)
        {
            xPos = xStartPos;
            yPos = yStartPos;
            _graphics = gd;
            _headTexture = head;
            _bodyTexture = body;
            length = 0;
            direction = "up";
        }
    }
}
