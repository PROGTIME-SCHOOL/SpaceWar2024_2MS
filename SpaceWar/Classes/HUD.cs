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
        private SheltBar sheltBar;
        private Label labelScore;
        private Label labelScoreText;
        public void LoadContent(ContentManager contentManager)
        {
            healthBar = new HealthBar(new Vector2(680, 560), 100, 10);
            sheltBar = new SheltBar(new Vector2(680, 580), 100, 10);
            labelScore = new Label("Score: 0", new Vector2(5, 0), Color.Red);
            //labelScoreText = new Label("Score: ", new Vector2(0,0),Color.Red);
            healthBar.LoadContent(contentManager);
            sheltBar.LoadContent(contentManager);
            labelScore.LoadContent(contentManager);
            //labelScoreText.LoadContent(contentManager);
        }
        public void Update(int score)
        {
            labelScore.Text = "Score: "+ score.ToString();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            healthBar.Draw(spriteBatch);
            sheltBar.Draw(spriteBatch);
            labelScore.Draw(spriteBatch);
            //labelScoreText.Draw(spriteBatch);
        }
        public void OnPlayerTakeDamage()
        {
            healthBar.Width = healthBar.Width - 10;
        }

        public void OnSheltUse(int percent)
        {
            sheltBar.Width = percent;
        }

        public void Reset()
        {
            healthBar.Width = 100;
            sheltBar.Width = 100;
            labelScore.Text = "Score: 0";
        }
    }
}
