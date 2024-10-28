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
        const int topSpeed = 5;
        bool isIdle = true;
        Rectangle idleFrame;
        //Point[] gunz = [
         //       new Point(106,36),
          //      new Rectangle(201, 32, 166, 235),
          //      new Rectangle(387, 22, 166, 256),
          //      new Rectangle(570, 32, 166, 235),
          //      new Rectangle(754, 24, 166, 252),
          //      ];
        public Player(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, Rectangle idleFrame, int frameDelay)
            : base(position, scale, image, frames, frameDelay)
        {
            this.idleFrame = idleFrame;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            base.Update(gameTime);
            isIdle = true;
            Speed.X = 0;
            Speed.Y = 0;

            Point rotation = new(mouse.Position.X - Hitbox.X, mouse.Position.Y - Hitbox.Y);

            Point movement = new Point(0, 0);
            if (keyboard.IsKeyDown(Keys.W)) { movement.Y += topSpeed; isIdle = false; }
            if (keyboard.IsKeyDown(Keys.S)) { movement.Y += -topSpeed; isIdle = false; }
            if (keyboard.IsKeyDown(Keys.A)) { movement.X += topSpeed; isIdle = false; }
            if (keyboard.IsKeyDown(Keys.D)) { movement.X += -topSpeed; isIdle = false; }

            if (Math.Abs(movement.X) + Math.Abs(movement.Y) != 0)
            {

                float value = (float)topSpeed / (Math.Abs(movement.X) + Math.Abs(movement.Y));
                Speed.X = (float)movement.X * (float)value;
                Speed.Y = (float)movement.Y * (float)value;
            }
            else //you on top of dude, don't move
            {
                Speed = new Vector2(0, 0);
            }
            Position = new Point(Position.X - (int)Speed.X, Position.Y - (int)Speed.Y);
            

            Rotation = -(float)Math.Atan2(rotation.Y, -rotation.X)-(float)Math.PI/2;
            if(mouse.LeftButton==ButtonState.Pressed)
            {

            }
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            if (isIdle)
            {
                spiteBatch.Draw(Image, new Rectangle(Position, new Point((int)(idleFrame.Width * Scale.X), (int)(idleFrame.Height * Scale.Y))), idleFrame, Color.White, Rotation, Origin.ToVector2(), SpriteEffects.None, 0);
            }
            else
            {
                base.RotatedDraw(spiteBatch, Rotation, Frames[currentFrame]);
            }
        }
    }
}