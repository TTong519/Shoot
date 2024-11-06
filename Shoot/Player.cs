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
        public int health;
        private bool prevState = false;
        public Vector2 Speed;
        readonly Point origin = new Point(90, 173);
        const int topSpeed = 5;
        bool isIdle = true;
        Rectangle idleFrame;
        Texture2D bulletTexture;
        List<Bullet> Bullets = new List<Bullet>();
        public Player(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, Rectangle idleFrame, int frameDelay, Texture2D bulletTexture)
            : base(position, scale, image, frames, frameDelay)
        {
            this.idleFrame = idleFrame;
            this.bulletTexture = bulletTexture;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse, GraphicsDevice gfx)
        {
            base.Update(gameTime);
            isIdle = true;
            Speed.X = 0;
            Speed.Y = 0;
            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Update();
                if(!Bullets[i].Hitbox.Intersects(gfx.Viewport.Bounds))
                {
                    Bullets.RemoveAt(i);
                }
            }
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
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                prevState = true;
            }

            else if (mouse.LeftButton == ButtonState.Released && prevState)
            {
                prevState = false;
                shoot(mouse.Position);
            }
            
            else
            {
                prevState = false;
            }
        }
        public void shoot(Point mouselocation)
        {
            Bullets.Add(new Bullet(new Point(Hitbox.X + origin.X/6, Hitbox.Y + origin.Y / 6), new Vector2(0.05f, 0.05f), bulletTexture, new Point((Hitbox.X + origin.X / 4)-20, (Hitbox.Y + origin.Y / 4)-50), mouselocation));
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (!Bullets[i].Hitbox.Intersects(Hitbox))
                {
                    Bullets[i].Draw(spiteBatch);
                }
            }
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