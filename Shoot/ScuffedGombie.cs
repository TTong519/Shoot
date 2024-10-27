using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    internal class ScuffedGombie : AnimatedSprite
    {
        Vector2 Speed;
        const int speed = 3;
        readonly Point origin = new Point(90, 173);
        public ScuffedGombie(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, int frameDelay) : base(position, scale, image, frames, frameDelay)
        {

        }
        public void Update(GameTime gameTime, Player player)
        {
            base.Update(gameTime);

            int x = player.Hitbox.X - Hitbox.X;
            int y = player.Hitbox.Y - Hitbox.Y;
            if (Math.Abs(x) + Math.Abs(y) != 0)
            {

                float value = (float)speed / (Math.Abs(x) + Math.Abs(y));
                Speed.X = (float)x * (float)value;
                Speed.Y = (float)y * (float)value;
            }
            else //you on top of dude, don't move
            { 
                Speed = new Vector2(0, 0);
            }

            Position = new Point((int)(Position.X + Speed.X), (int)(Position.Y + Speed.Y));

            Rotation = (float)Math.Atan2(y, x) + (float)Math.PI/2;
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.RotatedDraw(spiteBatch, Rotation, Frames[currentFrame]);
        }
    }
}