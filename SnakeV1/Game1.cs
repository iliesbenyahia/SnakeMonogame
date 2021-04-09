using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeV1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private snake _snake;
        private Texture2D _headTexture, _bodyTexture, _appleTexture;
        private SpriteFont _testFont;
        private level theLevel;
        public string test;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1720;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 880;   //+ set this value to the desired height of your window
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            _snake = new snake(0, 0, _graphics, _headTexture, _headTexture);
            theLevel = new level(5, 5);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _headTexture = Content.Load<Texture2D>("headSnake");
            _bodyTexture = Content.Load<Texture2D>("bodySnake");
            _testFont = Content.Load<SpriteFont>("test");
            _appleTexture = Content.Load<Texture2D>("red-apple");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update logic here

            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _snake.bodyParts[0].futureDirection = "up";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _snake.bodyParts[0].futureDirection = "down";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _snake.bodyParts[0].futureDirection = "right";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _snake.bodyParts[0].futureDirection = "left";
            }
            theLevel.update(_snake);
            _snake.move();
            

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _snake.Draw(_spriteBatch, _headTexture, _bodyTexture);
            _spriteBatch.Draw(_appleTexture, new Rectangle(theLevel.xApplePos, theLevel.yApplePos,40,40), Color.Wheat);
            _spriteBatch.DrawString(_testFont, "X pos : " + _snake.bodyParts[0].xPosition, new Vector2(0,0), Color.Black);
            _spriteBatch.DrawString(_testFont, "Y pos : " + _snake.bodyParts[0].yPosition, new Vector2(0, 20), Color.Black);
            _spriteBatch.DrawString(_testFont, "X apple pos : " + theLevel.xApplePos, new Vector2(0, 40), Color.Black);
            _spriteBatch.DrawString(_testFont, "Y apple pos : " + theLevel.yApplePos, new Vector2(0, 60), Color.Black);
            _spriteBatch.DrawString(_testFont, "Y pos : " + _snake.bodyParts[0].yPosition, new Vector2(0, 20), Color.Black);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
