using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net;
using System;

namespace Spaceship
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D shipSprite;
        private Texture2D asteroidSprite;
        private Texture2D spaceSprite;
        SpriteFont gameFont;
        SpriteFont timeFont;

        Ship player = new();
        Controller gameController = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipSprite = Content.Load<Texture2D>("ship");
            asteroidSprite = Content.Load<Texture2D>("asteroid");
            spaceSprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timeFont = Content.Load<SpriteFont>("timerFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameController.inGame)
            {
                player.shipUpdate(gameTime);
            }


            gameController.conUpdate(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].asteroidUpdate(gameTime);

                int sum = gameController.asteroids[i].radius + player.radius;
                if (Vector2.Distance(gameController.asteroids[i].position, player.position) < sum)
                {
                    gameController.inGame = false;
                    player.position = Ship.defaultPosition;
                    gameController.asteroids.Clear();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            float playerHeight = shipSprite.Height / 2;
            float playerWidth = shipSprite.Width / 2;

            _spriteBatch.Begin();
            _spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - playerHeight, player.position.Y - playerWidth), Color.White);


            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                var asteroid = gameController.asteroids[i];
                _spriteBatch.Draw(asteroidSprite,
                                   new Vector2(
                                                 asteroid.position.X - asteroid.radius,
                                                 asteroid.position.Y - asteroid.radius),
                                   Color.White);
            }

            if (!gameController.inGame)
            {
                string menuMessage = "Press Enter to Begin!";
                Vector2 sizeOfText = gameFont.MeasureString(menuMessage);

                int halfWidth = GraphicsDevice.Viewport.Width / 2;

                _spriteBatch.DrawString(gameFont, menuMessage, new Vector2(halfWidth - sizeOfText.X / 2, 200), Color.White);
            }

            _spriteBatch.DrawString(timeFont, "Time: " + Math.Floor(gameController.totalTime).ToString(), new Vector2(3, 3), Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
