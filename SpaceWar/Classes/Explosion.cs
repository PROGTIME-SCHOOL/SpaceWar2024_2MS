using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar.Classes
{
    internal class Explosion
    {
        private Texture2D texture;

        private Rectangle sourceRectangle;

        private int frameWidth;
        private int frameHeight;
        private int frameNumber; //  17

        private Vector2 position;
        private double duration; //длительность одного кадра
        private double totalTime;

        private bool isAlive;

        private bool isLoop = true;

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public Explosion(Vector2 position)
        {
            this.position = position;
            texture = null;
            duration = 0.05;
            frameNumber = 0;
            frameWidth = 117;
            frameHeight = 117;
            isAlive = true;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("explosion3");
        }
        public void Update(GameTime gameTime)
        {
            totalTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime > duration)
            {
                frameNumber++;

                totalTime = 0;
            }

            if (frameNumber == 17)
            {
                if (isLoop == true) 
                {
                    frameNumber = 0;
                } 
                isAlive = false;
            }

            sourceRectangle = new Rectangle(frameNumber * frameWidth, 0, frameWidth, frameHeight);

            Debug.WriteLine($"Time: {totalTime}                          ElapsedGameTime: {gameTime.ElapsedGameTime.TotalSeconds} ");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
        }
    }
}
