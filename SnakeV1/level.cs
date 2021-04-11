using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

            width = lvlWidth;
            height = lvlHeight;
            Random rand = new Random(); 
            xApplePos = rand.Next(1, width) *40;
            yApplePos = rand.Next(1, height) *40;
        }
        public void update(snake Serpent)
        {
            if(Serpent.bodyParts[0].xPosition == xApplePos && Serpent.bodyParts[0].yPosition == yApplePos)
            {
                Random rand = new Random();
                xApplePos = rand.Next(1, width) * 40;
                yApplePos = rand.Next(1, height) * 40;
                Serpent.grow();
            }
            if (Serpent.bodyParts[0].xPosition < 40 || Serpent.bodyParts[0].xPosition > width*40 || Serpent.bodyParts[0].yPosition < 40 || Serpent.bodyParts[0].yPosition > height * 40)
            {
                Serpent.die();
            }

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D _wallTexture)
        {
            for(int i =0; i<=width+1; i++)
            {
                spriteBatch.Draw(_wallTexture, new Vector2(i * 40,0), Color.Wheat);
                spriteBatch.Draw(_wallTexture, new Vector2(i * 40, (width+1)*40), Color.Wheat);
            }
            for (int i = 0; i <=height; i++)
            {
                spriteBatch.Draw(_wallTexture, new Vector2(0, i * 40), Color.Wheat);
                spriteBatch.Draw(_wallTexture, new Vector2((height+1) * 40, i * 40), Color.Wheat);
            }
        }
    }
}
