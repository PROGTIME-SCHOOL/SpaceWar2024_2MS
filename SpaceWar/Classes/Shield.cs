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
    class Shield
    {
        private const int timeUse = 600;
        private const int timeRegenerate = 700;

        private Texture2D texture;
        private int width;
        private int height;
        private bool isCanBeUsed;
        private bool isActive;
        private int timer;

        public event Action<int> Shielduse;

        public Texture2D Texture
        {
            get { return texture; }
        }
        public bool IsActive
        {
            get { return isActive; }
        }

        public Shield()
        {
            isCanBeUsed = true;
            isActive = false;
            timer = timeUse;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("shelt");

            width = texture.Width;
            height= texture.Height;
        }
        public void Update()// E - активация
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.E))
            {
                if(isCanBeUsed==true)
                {
                    isActive = true;
                    isCanBeUsed = false;
                }  
            }

            if(timer > 0 && isCanBeUsed == false)
            {
                timer--;
            }
            if(timer <= 0)
            {
                if (isActive)
                {
                    isActive = false;
                }
                else
                {
                    timer = timeUse;
                    isCanBeUsed = true;
                    OnShieldUsed(100);
                }    
            }
            if(timer<=0 && isCanBeUsed == false && IsActive==false) 
            {
                timer = timeRegenerate;
            }
            if(IsActive==true && isCanBeUsed==false)
            {
                OnShieldUsed(timer * 100 / timeUse);
            }
            if (IsActive == false && isCanBeUsed == false)
            {
                OnShieldUsed((timeRegenerate-timer) * 100 / timeRegenerate);
            }
        }
        public void OnShieldUsed(int percent)
        {
            if(Shielduse != null)
            {
                Shielduse(percent);
            }
        }
    }
}
