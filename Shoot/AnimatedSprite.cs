using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{//4532 Gaviota Ct Encino CA 91436
    //Elias Lawrence Plishner
    //(310) 621-4883
    //Emily Glickfeld Plishner
    //Michael Glickfeld
    //(818) 917-4152
    internal class AnimatedSprite : Sprite
    {
        protected int time = 0;
        protected int frameDelay;
        protected int currentFrame;
        public Rectangle[] Frames;
        public override Rectangle Hitbox => new Rectangle(Position, new Point((int)(Frames[currentFrame].Width * Scale.X), (int)(Frames[currentFrame].Height * Scale.Y)));
        
        public AnimatedSprite(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, int frameDelay)
            : base(position, scale, image)
        {
            Frames = frames;
            this.frameDelay = frameDelay;
            Origin = new Point(90, 173);
        }

        public virtual void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time >= frameDelay)
            {
                //change currentFrame
                currentFrame++;
                if (currentFrame >= Frames.Length)
                {
                    currentFrame = 0;
                }
                time = 0;
            }
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            spiteBatch.Draw(Image, Hitbox, Frames[currentFrame], Color.White);
        }
    }
}
