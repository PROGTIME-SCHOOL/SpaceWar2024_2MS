using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SpaceWar.Classes;
using SpaceWar.Classes.Components;
using System;
using SharpDX.XAudio2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private List<Explosion> explosions;
        private int screenWidth;
        private int screenHeight;

        private int asteroidAmount;

        

        int score = 0;

        private MainMenu mainMenu;
        private GameOver gameOver;
        private HUD hud;

        public static GameMode gameMode;

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
            explosions = new List<Explosion>();

            mainMenu = new MainMenu();
            gameOver = new GameOver();
            hud = new HUD();
            player.TakeDamage += hud.OnPlayerTakeDamage;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            space.LoadContent(Content);
            

            mainMenu.LoadContent(Content);
            gameOver.LoadContent(Content);
            hud.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here



            switch (gameMode)
            {
                case GameMode.Menu:
                    mainMenu.Update();
                    break;
                case GameMode.Playing:
                    player.Update(Content);
                    space.Update();
                    UpdateAsteroid();
                    CheckCollision();
                    UpdateExplosion(gameTime);
                    hud.Update(score);
                    break;
                case GameMode.GameOver:
                    gameOver.Update();
                    break;
                case GameMode.Exit:
                    Exit();
                    break;
                default:
                    break;
            }


            


            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            switch (gameMode)
            {
                case GameMode.Menu:
                    mainMenu.Draw(_spriteBatch);
                    break;
                case GameMode.Playing:
                    space.Draw(_spriteBatch);

                    player.Draw(_spriteBatch);

                    foreach (Asteroid a in asteroids)
                    {
                        a.Draw(_spriteBatch);
                    }
                    foreach (Explosion exp in explosions)
                    {
                        exp.Draw(_spriteBatch);
                    }

                   hud.Draw(_spriteBatch);
                   
                    break;
                case GameMode.GameOver:
                    gameOver.Draw(_spriteBatch);
                    break;
                case GameMode.Exit:
                    break;
                default:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private void LoadExplotion(Vector2 pos)
        {
            Explosion exp = new Explosion(pos);
            exp.LoadContent(Content);
            explosions.Add(exp);
        }

        private void LoadAsteroid()
        {
            Asteroid asteroid = new Asteroid();

            asteroid.LoadContent(Content);

            bool isSpawnNormal = false;

            do
            {
                Random random = new Random();

                int x = random.Next(0, screenWidth - asteroid.Width);
                int y = random.Next(0 - screenHeight - asteroid.Height, 0);

                asteroid.Position = new Vector2(x, y);
                asteroid.Collision = new Rectangle(x, y, asteroid.Width, asteroid.Height);

                bool flag = false;

                foreach (Asteroid a in asteroids)
                {
                    if (asteroid.Collision.Intersects(a.Collision))
                    {
                        //если есть пересечение
                        flag = true;
                    }
                }
                //2
                if (flag == false)
                {
                    isSpawnNormal = true;
                }

            } while (isSpawnNormal == false);


            asteroids.Add(asteroid);
        }
        private void CheckCollision()
        {
            foreach (Asteroid a in asteroids)
            {
                if (a.Collision.Intersects(player.Collision))
                {
                    a.IsAlive = false;
                    //уменьшение hp игрока
                    //изменение healthbar
                    player.Damage();
                    LoadExplotion(a.Position);
                    if(player.Health<=0)
                    {
                        gameMode = GameMode.GameOver; 
                        break;
                    }
                }
                foreach (Bullet b in player.BulletList)
                {
                    if (a.Collision.Intersects(b.Collision))
                    {
                        a.IsAlive = false;
                        b.IsAlive = false;
                        LoadExplotion(a.Position);
                        score++;
                    }
                }
            }

        }
        private void UpdateExplosion(GameTime gametime)
        {
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Update(gametime);
                if (explosions[i].IsAlive == false)
                {
                    explosions.Remove(explosions[i]);
                    i--;
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