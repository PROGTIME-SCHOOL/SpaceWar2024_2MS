using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes
{
    public class HealBoost
    {
        public const int Speed = 2;
        public const int TimeRespawn = 1000;

        private Texture2D texture;
        private Vector2 position;
        private bool isVisible;
        private Rectangle collision;

        private Random random;
        private int timer;

        public Rectangle Collision
        {
            get { return collision; }
        }

        public bool IsVisible
        {
            set { isVisible = value; }
            get { return isVisible; }
        }

        public HealBoost()
        {
            random = new Random();
            texture = null;

            Reset();
        }

        public void Reset()
        {
            position = new Vector2(random.Next(0,  750), -50);
            isVisible = false;
            timer = random.Next(0, TimeRespawn + 1);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("healBoost");
        }


        public void Update()
        {
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (isVisible == true)
            {
                position.Y += Speed;
            }

            if (position.Y > 600)
            {
                position.Y = -50;
                isVisible = false;
            }

            if (isVisible == false)
            {
                if (timer >= TimeRespawn)
                {
                    timer = 0;
                    isVisible = true;
                }

                timer++;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible == true)
            {
                spriteBatch.Draw(texture, collision, Color.White);
            }
        }
    }
}
