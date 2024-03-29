using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes.Components
{
    class HealthBar
    {
        private Texture2D texture;
        private Vector2 position;
        private int width;
        private int height;

        public int Width 
        {
            get { return width; }
            set { width = value; }
        }
        public Rectangle DestinationRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, width, height); }
        }

        public HealthBar(Vector2 position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("healthbar");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, DestinationRectangle, Color.White);
        }
    }
}
