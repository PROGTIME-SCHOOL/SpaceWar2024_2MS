using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceWar.Classes
{
    public class Player
    {
        private Vector2 position;
        private Texture2D texture;
        private float speed;

        private Rectangle collision;

        private List<Bullet> bulletList;

        private int time;
        private int maxTime;

        public Rectangle Collision
        {
            get { return collision; }
        }
        public List<Bullet> BulletList
        {
            get { return bulletList; }
        }
        public Player()
        {
            position = new Vector2(50, 350);
            speed = 10;
            texture = null;
            bulletList = new List<Bullet>();
            time = 0;
            maxTime = 60;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public void Update(ContentManager manager)
        {
            time++;
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }

            if (time > maxTime)
            {
                Bullet b = new Bullet(5,5);
                b.LoadContent(manager);
                b.Position = new Vector2((int)position.X + texture.Width / 2 - b.Width / 2, (int)position.Y);
                bulletList.Add(b);
                time = 0;
            }
            /*if (keyboardState.IsKeyDown(Keys.Space))
            {
                Bullet b = new Bullet((int)position.X, (int)position.Y);
                b.LoadContent(manager);
                bulletList.Add(b);
            }*/

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].IsAlive == false)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }

            if (position.X + texture.Width > 800)
            {
                position.X = 800 - texture.Width;
            }

            if (position.Y + texture.Height > 600)
            {
                position.Y = 600 - texture.Height;
            }

            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update();
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, position, Color.White);

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(_spriteBatch);
            }
        }
    }
}
