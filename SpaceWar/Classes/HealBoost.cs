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
    public  class HealBoost
    {
        public const int Speed = 2;

        private Vector2 position;
        private Texture2D texture;
        private bool isAlive;

        private Rectangle collision;

        public Vector2 Position
        {
            get { return position; } 
        }
        public Rectangle Collision
        {
            get { return collision; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public HealBoost(Vector2 position)
        {
            texture = null;

            this.position = position;
            isAlive = true;
        }
        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("boosterHP");
        }
        public void Update()
        {
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            position.Y += Speed;

            //if (position.Y > 650)
            //{
            //    //удаление
            //}
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, collision, Color.White);
        }
    }
}
