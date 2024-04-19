using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceWar.Classes.Components;

namespace SpaceWar.Classes
{
    public class PauseMenu
    {
        private List<Label> buttonList = new List<Label>();

        private int selected;

        private Color selectedColor;

        private KeyboardState keyboardState;
        private KeyboardState prevKeyBoardState;

        public PauseMenu(int width, int height)
        {
            selected = 0;
            selectedColor = Color.Yellow;

            buttonList.Add(new Label("Continue", Color.White));
            buttonList.Add(new Label("Save Game (In progress)", Color.White));
            buttonList.Add(new Label("Exit in menu", Color.White));

            int centerY = height / 2;

            if (buttonList.Count % 2 == 0)
            {
                centerY = centerY - (35 * buttonList.Count / 2);
            }
            else
            {
                centerY = centerY - (35 * (buttonList.Count - 1) / 2) - 15;
            }

            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Position = new Vector2(width / 2, centerY);
                centerY = centerY + 35;
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
            foreach (var button in buttonList)
            {
                button.LoadContent(contentManager);

                Vector2 sizeText = button.SizeString(button.Text);

                button.Position = new Vector2(button.Position.X - sizeText.X / 2, button.Position.Y);
            }
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();

            if (CheckKeyBoard(Keys.S)) //только что отпустил
            {
                if (selected < buttonList.Count - 1)
                {
                    selected = selected + 1;
                }
                else // Зацикливаем
                {
                    selected = 0;
                }
            }

            if (CheckKeyBoard(Keys.W))
            {
                if (selected > 0)
                {
                    selected = selected - 1;
                }
                else
                {
                    selected = buttonList.Count - 1;
                }
            }

            prevKeyBoardState = keyboardState;

            //Click key->Enter
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                if (selected == 0)// Continue
                {
                    Game1.gameMode = GameMode.Playing;
                }
                else if (selected == 1) // Save
                {
                    // Waiting new update...
                }
                else if (selected == 2)
                {
                    Game1.gameMode = GameMode.Menu;
                }
            }
        }

        public bool CheckKeyBoard(Keys key)
        {
            // Обязательно, что перед prevKeyBoardState восклицательный знак !!!!!
            // Сделано, чтобы перематовалось только на 1 пункт
            return (keyboardState.IsKeyDown(key) && !prevKeyBoardState.IsKeyDown(key));
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < buttonList.Count; i++)
            {
                if (i == selected)
                {
                    buttonList[i].Color = selectedColor;
                }
                else
                {
                    buttonList[i].Color = Color.White;
                }

                buttonList[i].Draw(spriteBatch);
            }
        }
    }
}
