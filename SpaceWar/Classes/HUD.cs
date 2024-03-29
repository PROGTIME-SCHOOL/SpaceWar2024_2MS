using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWar.Classes.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes
{
    class HUD
    {
        private HealthBar healthBar;
        private Label labelScore;
        public void LoadContent(ContentManager contentManager)
        {
            healthBar = new HealthBar(new Vector2(680, 580), 100, 10);
            labelScore = new Label("0", new Vector2(0, 0), Color.Red);
            healthBar.LoadContent(contentManager);
            labelScore.LoadContent(contentManager);
        }
        public void Update(int score)
        {
            labelScore.Text = score.ToString();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            healthBar.Draw(spriteBatch);
            labelScore.Draw(spriteBatch);
        }
        public void OnPlayerTakeDamage()
        {
            healthBar.Width = healthBar.Width - 10;
        }
    }
}
