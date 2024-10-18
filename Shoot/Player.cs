using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    internal class Player : AnimatedSprite
    {
        Vector3 speed;
        readonly Point origin = new Point(90, 173);
        public Player(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, Rectangle idleFrame, int frameDelay)
            : base(position, scale, image, frames, frameDelay)
        {

        }

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            int x =  - Hitbox.X;
            int y = player.Hitbox.Y - Hitbox.Y;
            base.Update(gameTime);
            if (keyboard.IsKeyDown(Keys.W))
            {

            }
            Position = new Point(Position.X - (int)speed.X, Position.Y - (int)speed.Y);

            float hyp = (float)Math.Sqrt((x * x) + (y * y));
            Rotation = (float)Math.Asin((float)(y / hyp));
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.Draw(spiteBatch);
        }
    }
}