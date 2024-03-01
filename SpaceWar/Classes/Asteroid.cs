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
    public class Asteroid
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed;
        private Rectangle collision;
        private bool isAlive;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Collision
        {
            get { return collision; }
        }
        public int Height
        {
            get { return texture.Height; }
        }
        public int Width
        {
            get { return texture.Width; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Asteroid()
        {
            texture = null;
            position = new Vector2(0, 0);
            speed = 10;//2
            isAlive = true;
        }
        public Asteroid(Vector2 pos) : this() 
        {
            position = pos;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("asteroid");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void Update()
        {
            position.Y += speed;

            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
    }
}