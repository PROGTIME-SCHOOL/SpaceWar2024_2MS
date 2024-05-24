using SpaceWar.Classes.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceWar.Classes
{
    class GameOver
    {
        private Label label;
        private Label lblScore;
        private Label lblMaxScore;

        public GameOver(int width, int height)
        {
            label = new Label("GAME OVER!!!", new Vector2(width / 2 - 45, height / 2), Color.White);
            lblScore = new Label("Your score: ", new Vector2(width / 2 - 45, height / 2 + 30), Color.White);
            lblMaxScore = new Label("Record: ", new Vector2(width / 2 - 45, height / 2 + 60), Color.White);
        }
        public void AddScores(string playerScore, string totalScore) 
        {
            lblScore.Text += playerScore;
            lblMaxScore.Text += totalScore;
        }
        public void Restart()
        {
            lblScore.Text = "Your score: ";
            lblMaxScore.Text = "Record: ";
        }
        public void LoadContent(ContentManager contentManager)
        {
            label.LoadContent(contentManager);
            lblScore.LoadContent(contentManager);
            lblMaxScore.LoadContent(contentManager);
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game1.gameMode = GameMode.Menu;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            label.Draw(spriteBatch);
            lblScore.Draw(spriteBatch);
            lblMaxScore.Draw(spriteBatch);
        }
    }
}
