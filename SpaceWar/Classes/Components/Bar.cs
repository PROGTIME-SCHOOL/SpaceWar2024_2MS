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
    public class Bar
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected int width;
        protected int height;
        protected string nameTexture;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, width, height); }
        }

        public Bar(Vector2 position, int width, int height, string nameTexture)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.nameTexture = nameTexture;
        }

        public virtual void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>(nameTexture);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, DestinationRectangle, Color.White);
        }
    }
}
