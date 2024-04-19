using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceWar.Classes.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes
{
    public class Shelt
    {
        private const int TimeRegenerate = 700;
        private const int TimeUse = 600;

        private Texture2D texture;
        private int width;
        private int height;
        private bool isActive;
        private bool isCanUse;
        private int timer;

        public event Action<int> SheltUse;

        public Texture2D Texture { get { return texture; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public bool IsActive { get { return isActive; } }


        public Shelt()
        {
            Reset();
        }

        public void Reset()
        {
            isCanUse = true;
            isActive = false;
            timer = TimeUse;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("shelt");

            width = texture.Width;
            height = texture.Height;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Q))
            {
                if (isCanUse)
                {
                    isCanUse = false;
                    isActive = true;
                }
            }

            if (timer > 0)
            {
                timer--;
            }

            if (timer <= 0)
            {
                if (isActive)
                {
                    isActive = false;
                }
                else
                {
                    timer = TimeUse;
                    isCanUse = true;
                    OnSheltUse(100);
                }
            }    

            if (timer == 0 && !isCanUse && !isActive)
            {
                timer = TimeRegenerate;
            }

            if (!isCanUse && isActive)
            {
                OnSheltUse(timer * 100 / TimeUse);
            }

            if (!isCanUse && !isActive)
            {
                OnSheltUse((TimeRegenerate - timer) * 100 / TimeRegenerate);
            }
        }

        public void OnSheltUse(int percent)
        {
            if (SheltUse != null)
            {
                SheltUse(percent);
            }
        }
    }
}
