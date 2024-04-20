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
    public class SheltBar : Bar
    {
        private Texture2D backTexture;
        private int maxWidth;

        public SheltBar(Vector2 position, int width, int height) : base(position, width, height, "sheltBar")
        {
            maxWidth = width;
        }

        public override void LoadContent(ContentManager manager)
        {
            backTexture = manager.Load<Texture2D>("sheltBarBack");

            base.LoadContent(manager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle backDestinationRectangle = new Rectangle(
                (int)position.X,
                (int)position.Y,
                maxWidth,
                height
            );

            spriteBatch.Draw(backTexture, backDestinationRectangle, Color.White);

            base.Draw(spriteBatch);
        }
    }
}
