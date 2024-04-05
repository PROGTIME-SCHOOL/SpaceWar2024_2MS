using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes
{
    public class Space
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;

        private float speed;

        public Space()
        {
            texture = null;
            Reset();
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("space");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }

        public void Update()
        {
            position1.Y += speed;
            position2.Y += speed;

            if (position2.Y >= 0)
            {
                position1.Y = 0;
                position2.Y = -950;
            }
        }

        public void Reset()
        {
            position1 = new Vector2(0, 0);
            position2 = new Vector2(0, -950);
            speed = 1;
        }
    }
}
