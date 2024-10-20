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
        public Player(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, Rectangle idleFrame, int frameDelay, int speed)
            : base(position, scale, image, frames, frameDelay)
        {
            this.speed.Z = speed;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            int x = mouse.Position.X - Hitbox.X;
            int y = mouse.Position.Y - Hitbox.Y;
            base.Update(gameTime);
            if (keyboard.IsKeyDown(Keys.W))
            {
                speed.Y = speed.Z;
            }
            if(keyboard.IsKeyDown(Keys.S)) 
            { 
                speed.Y = -speed.Z; 
            }
            if(keyboard.IsKeyDown(Keys.D))
            {
                speed.X = -speed.Z;
            }
            if(keyboard.IsKeyDown (Keys.A))
            {
                speed.X = speed.Z;
            }
            Position = new Point(Position.X - (int)speed.X, Position.Y - (int)speed.Y);
            float hyp = (float)Math.Sqrt((x * x) + (y * y));
           
            Rotation = -(float)Math.Atan2(y,-x)-90;
            speed.X = 0;
            speed.Y = 0;
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.RotatedDraw(spiteBatch, Rotation);
        }
    }
}