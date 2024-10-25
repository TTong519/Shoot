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
        Vector2 Speed;
        readonly Point origin = new Point(90, 173);
        const int topSpeed = 10;
        public Player(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, Rectangle idleFrame, int frameDelay)
            : base(position, scale, image, frames, frameDelay)
        {
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            base.Update(gameTime);
            Speed.X = 0;
            Speed.Y = 0;

            Point rotation = new(mouse.Position.X - Hitbox.X, mouse.Position.Y - Hitbox.Y);

            Point movement = new Point(0, 0);
            if (keyboard.IsKeyDown(Keys.W)) movement.Y += topSpeed;
            if (keyboard.IsKeyDown(Keys.S)) movement.Y += -topSpeed;
            if (keyboard.IsKeyDown(Keys.A)) movement.X += topSpeed;
            if (keyboard.IsKeyDown(Keys.D)) movement.X += -topSpeed;

            if (Math.Abs(movement.X) + Math.Abs(movement.Y) != 0)
            {

                float value = (float)topSpeed / (Math.Abs(movement.X) + Math.Abs(movement.Y));
                Speed.X = (int)(movement.X * value);
                Speed.Y = (int)(movement.Y * value);
            }
            else //you on top of dude, don't move
            {
                Speed = new Vector2(0, 0);
            }
            Position = new Point(Position.X - (int)Speed.X, Position.Y - (int)Speed.Y);
            

            Rotation = -(float)Math.Atan2(rotation.Y, -rotation.X)-(float)Math.PI/2;
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.RotatedDraw(spiteBatch, Rotation);
        }
    }
}