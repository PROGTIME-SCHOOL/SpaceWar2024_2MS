using Microsoft.Xna.Framework.Input;
using SpaceWar.Classes.Components;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes
{
    public class PauseMenu
    {
        private List<Label> buttonlist = new List<Label>();

        private int selected;

        private Color selectedColor;

        private KeyboardState keyboardState;
        private KeyboardState prevKeyboardState;

        public PauseMenu(int width, int height)
        {
            selected = 0;
            selectedColor = Color.Yellow;

            buttonlist.Add(new Label("Continue", Color.White));
            buttonlist.Add(new Label("Exit to menu", Color.White));

            int centerY = height / 2;
            if (buttonlist.Count % 2 == 0)
            {
                centerY = centerY - (35 * buttonlist.Count / 2);
            }
            else
            {
                centerY = centerY - (35 * (buttonlist.Count - 1) / 2);
            }
            for (int i = 0; i < buttonlist.Count; i++)
            {
                buttonlist[i].Position = new Vector2(width / 2, centerY);
                centerY += 35;
            }
        }
        public void LoadContent(ContentManager manager)
        {
            foreach (Label button in buttonlist)
            {
                button.LoadContent(manager);

                Vector2 sizeText = button.SizeString(button.Text);
                button.Position = new Vector2(button.Position.X - sizeText.X / 2, button.Position.Y);
            }
        }
        public void Update()
        {
            keyboardState = Keyboard.GetState();
            if (prevKeyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyUp(Keys.S))//только что отпустил
            {
                if (selected < buttonlist.Count - 1)
                {
                    selected = selected + 1;
                }

            }

            if (prevKeyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyUp(Keys.W))
            {
                if (selected > 0)
                {
                    selected = selected - 1;
                }
            }
            

            //Click key->Enter
            if (prevKeyboardState.IsKeyDown(Keys.Enter) && keyboardState.IsKeyUp(Keys.Enter))
            {
                if (selected == 0)//Start
                {
                    Game1.gameMode = GameMode.Playing;
                }
                else if (selected == 1)//Exit
                {
                    Game1.gameMode = GameMode.Menu;
                }
            }
            prevKeyboardState = keyboardState;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < buttonlist.Count; i++)
            {
                if (i == selected)
                {
                    buttonlist[i].Color = selectedColor;
                }
                else
                {
                    buttonlist[i].Color = Color.White;
                }
                buttonlist[i].Draw(spritebatch);
            }
        }
    }
}
