using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceWar.Classes
{
    public class Bullet
    {
        private Texture2D texture;
        private Rectangle destinationRactangle;

        public Bullet()
        {
            texture = null;
            destinationRactangle = new Rectangle(0, 0, 20, 20);
        }
        public Bullet(int x, int y)
        {
            texture = null;
            destinationRactangle = new Rectangle(x, y, 20, 20);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("asteroid");
        }
        public void Update()
        {
            destinationRactangle.Y -= 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRactangle, Color.White);
        }
    }
}
