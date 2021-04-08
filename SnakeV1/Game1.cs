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
        private Texture2D _headTexture, _bodyTexture;
        private SpriteFont _testFont;
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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _headTexture = Content.Load<Texture2D>("headSnake");
            _testFont = Content.Load<SpriteFont>("test");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_headTexture, new Vector2(_snake.xPos, _snake.yPos), Color.Wheat);
            _spriteBatch.DrawString(_testFont, "test", Vector2.Zero, Color.Black);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
