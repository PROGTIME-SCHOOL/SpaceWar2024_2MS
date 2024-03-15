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
    class Label
    {
        private string text;
        private Color color;
        private Vector2 position;
        private SpriteFont spriteFont;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Label(string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;

            spriteFont = null;
        }

        public void LoadContent(ContentManager manager)
        {
            spriteFont = manager.Load<SpriteFont>("GameFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, text, position, color);
        }
    }
}
