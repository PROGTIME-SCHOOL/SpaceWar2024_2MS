using SpaceWar.Classes.Components;
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
    class GameOver
    {
        private Label label;

        public GameOver()
        {
            label = new Label("GAME OVER!!!", new Vector2(200, 200), Color.White);
        }
        public void LoadContent(ContentManager contentManager)
        {
            label.LoadContent(contentManager);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            label.Draw(spriteBatch);
        }
    }
}
