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
    class MainMenu
    {
        private List<Label> buttonList = new List<Label>();

        private int selected;

        private Color selectedColor;

        private KeyboardState keyboardState;
        private KeyboardState prevKeyBoardState;

        public MainMenu()
        {
            selected = 0;
            selectedColor = Color.Black;

            buttonList.Add(new Label("Play", new Vector2(50, 50), Color.White));
            buttonList.Add(new Label("Exit", new Vector2(50, 100), Color.White));
            //buttonList.Add(new Label("Exit", new Vector2(50, 150), Color.White));
            //buttonList.Add(new Label("Exit", new Vector2(50, 200), Color.White));
            //buttonList.Add(new Label("Exit", new Vector2(50, 250), Color.White));
            //buttonList.Add(new Label("Exit", new Vector2(50, 300), Color.White));
            //buttonList.Add(new Label("Exit", new Vector2(50, 350), Color.White));
            //buttonList.Add(new Label("Exit", new Vector2(50, 400), Color.White));
        }

        public void LoadContent(ContentManager contentManager)
        {
            foreach (var button in buttonList)
            {
                button.LoadContent(contentManager);
            }
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();

            if (prevKeyBoardState.IsKeyDown(Keys.S) && keyboardState.IsKeyUp(Keys.S))//только что отпустил
            {
                if (selected < buttonList.Count - 1)
                {
                    selected = selected + 1;
                }

            }

            if (prevKeyBoardState.IsKeyDown(Keys.W) && keyboardState.IsKeyUp(Keys.W))
            {
                if (selected > 0)
                {
                    selected = selected - 1;
                }
            }
            prevKeyBoardState = keyboardState;

            //Click key->Enter
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                if (selected == 0)//Start
                {
                    Game1.gameMode = GameMode.Playing;
                }
                else if (selected == 1)//Exit
                {
                    Game1.gameMode = GameMode.Exit;
                }
            }
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
