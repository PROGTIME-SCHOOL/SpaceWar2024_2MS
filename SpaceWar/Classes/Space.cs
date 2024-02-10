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
        private Vector2 position;

        public Space()
        {
            texture = null;
            position = new Vector2(0, 0);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("space");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update()
        {

        }
    }
}
