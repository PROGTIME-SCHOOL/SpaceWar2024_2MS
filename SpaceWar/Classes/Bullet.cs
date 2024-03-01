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
        private int width;
        private int height;
        private bool isAlive;

        public Vector2 Position
        {
            get { return new Vector2(destinationRactangle.X, destinationRactangle.Y); }
            set
            {
                destinationRactangle.X = (int)value.X;
                destinationRactangle.Y = (int)value.Y;
            }
        }

        public Rectangle Collision
        {
            get { return destinationRactangle; }
        }

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public Bullet()
        {
            texture = null;
            width = 20;
            height = 20;
            destinationRactangle = new Rectangle(0, 0, width, height);
            isAlive = true;
        }
        public Bullet(int x, int y) : this()
        {
            destinationRactangle = new Rectangle(x, y, width, height);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("asteroid");
        }
        public void Update()
        {
            destinationRactangle.Y -= 3;

            if (Position.Y < 0 - height - 5)
            {
                isAlive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRactangle, Color.White);
        }
    }
}
