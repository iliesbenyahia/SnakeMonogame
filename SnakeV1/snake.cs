using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeV1
{
    class snake
    {
        public bool isAlive, allowMoving = true; 
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
            bodyParts[0].head = true;
        }

        public void move()
        {
            if (allowMoving)
            {
                for (int i = 0; i < bodyParts.Count; i++)
                {
                    bodyParts[i].move();
                }
                if (bodyParts[0].reachedTarget)
                {
                    bodyParts[bodyParts.Count - 1].isNew = false;
                    for (int i = bodyParts.Count - 1; i > 0; i = i - 1)
                    {
                        bodyParts[i].currentDirection = bodyParts[i].futureDirection;
                        bodyParts[i].futureDirection = bodyParts[i - 1].currentDirection;
                    }
                }
            }

        }

        public void grow()
        {
            int xNewPos = bodyParts[bodyParts.Count - 1].xPosition;
            int yNewPos = bodyParts[bodyParts.Count - 1].yPosition;
            bodyParts.Add(new snakePart(bodyParts[bodyParts.Count - 1].currentDirection, bodyParts[bodyParts.Count - 1].currentDirection, xNewPos, yNewPos));
        }

        public void Draw(SpriteBatch _spriteBatch, Texture2D _headTexture, Texture2D _bodyTexture)
        {
            foreach (snakePart aSnakePart in this.bodyParts)
            {
                if (!aSnakePart.head)
                {
                    _spriteBatch.Draw(_bodyTexture, new Vector2(aSnakePart.xPosition, aSnakePart.yPosition), Color.Wheat);
                }
                else
                {
                    float angle = (float) Math.PI;
                    var origin = new Vector2(_headTexture.Width/2, _headTexture.Height/2);
                    if(bodyParts[0].currentDirection == "right")
                    {
                        angle = (float)(Math.PI / 2.0);
                    }
                    if (bodyParts[0].currentDirection == "left")
                    {
                        angle = -(float)(Math.PI / 2.0);
                    }
                    if (bodyParts[0].currentDirection == "up")
                    {
                        angle = 0; //on considère que la texture de la tête du serpent regarde vers le haut dès le début
                    }
                    if (bodyParts[0].currentDirection == "down")
                    {
                        angle = -(float)(Math.PI);
                    }

                    _spriteBatch.Draw(_headTexture, new Vector2 (bodyParts[0].xPosition+20, bodyParts[0].yPosition+20),new Rectangle(0, 0, 40, 40), Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
                }
            }
        }
    }
}
