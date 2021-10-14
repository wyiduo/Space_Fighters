﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Our_First_Game
{
    class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public int CurrentFrame
        {
            get
            {
                return currentFrame;
            }
            private set
            {
                currentFrame = value;
            }
        }
        public int TotalFrames
        {
            get
            {
                return totalFrames;
            }
            private set
            {
                totalFrames = value;
            }
        }

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
        }

        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float scale)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(width * scale), (int)(height * scale));

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}