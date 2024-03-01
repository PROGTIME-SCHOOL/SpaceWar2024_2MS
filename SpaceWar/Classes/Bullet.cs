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
        private int size;
        private bool isAlive;

        public Rectangle DestinationRactangle
        {
            set { destinationRactangle = value; }
        }

        public int Width
        {
            get { return size; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public Bullet()
        {
            texture = null;
            size = 20;
            destinationRactangle = new Rectangle(0, 0, size, size);
        }
        public Bullet(int x, int y)
        {
            texture = null;
            size = 20;
            destinationRactangle = new Rectangle(x, y, size, size);
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
