using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SpaceWar.Classes;
using System;
using SharpDX.XAudio2;

namespace SpaceWar
{
    public class Game1 : Game
    {
        // Иструменты
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Поля
        private Player player;
        private Space space;

        private List<Asteroid> asteroids;
        private int screenWidth;
        private int screenHeight;

        private int asteroidAmount;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            screenWidth = 800;
            screenHeight = 600;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;

            asteroidAmount = 10;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            player = new Player();
            space = new Space();
            asteroids = new List<Asteroid>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            space.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(Content);
            space.Update();
            UpdateAsteroid();
            CheckCollision();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            space.Draw(_spriteBatch);

            player.Draw(_spriteBatch);

            foreach (Asteroid a in asteroids)
            {
                a.Draw(_spriteBatch);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void LoadAsteroid()
        {
            Asteroid asteroid = new Asteroid();

            asteroid.LoadContent(Content);


            do while (true)
                {
                    Random random = new Random();

                    int x = random.Next(0, screenWidth - asteroid.Width);
                    int y = random.Next(0 - screenHeight - asteroid.Height, 0);

                    asteroid.Position = new Vector2(x, y);
                }
            foreach (Asteroid a in asteroids)
            {
                if (asteroid.Collision.Intersects(a.Collision))
                {
                    random = new Random();

                    x = random.Next(0, screenWidth - asteroid.Width);
                    y = random.Next(0 - screenHeight - asteroid.Height, 0);

                    asteroid.Position = new Vector2(x, y);
                }
            }

            asteroids.Add(asteroid);
        }
        private void CheckCollision()
        {
            foreach (Asteroid a in asteroids)
            {
                if (a.Collision.Intersects(player.Collision))
                {
                    a.IsAlive = false;
                }
                foreach (Bullet b in player.BulletList)
                {
                    if (a.Collision.Intersects(b.Collision))
                    {
                        a.IsAlive = false;
                        b.IsAlive = false;
                    }
                }
            }

        }
        private void UpdateAsteroid()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                Asteroid a = asteroids[i];

                a.Update();

                //teleport
                if (a.Position.Y > screenHeight + 50)
                {
                    Random random = new Random();

                    int x = random.Next(0, screenWidth - a.Width);
                    int y = random.Next(0 - screenHeight - a.Height, 0);

                    a.Position = new Vector2(x, y);
                }
                if (a.IsAlive == false)
                {
                    asteroids.RemoveAt(i);
                    i--;
                }
            }
            //загрузить доп астероид
            if (asteroids.Count < asteroidAmount)
            {
                LoadAsteroid();
            }
        }
    }
}