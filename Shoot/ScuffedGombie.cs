using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Shoot
{
    internal class ScuffedGombie : AnimatedSprite
    {
        public Vector2 Speed;
        const int speed = 3;
        readonly Point origin = new Point(90, 173);
        Point direction;
        public ScuffedGombie(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, int frameDelay) : base(position, scale, image, frames, frameDelay)
        {

        }
        public void Update(GameTime gameTime, Player player)
        {
            base.Update(gameTime);
            int x = 0;
            int y = 0;
            int playerX = Abs(player.Hitbox.X);
            int playerY = Abs(player.Hitbox.Y);
            int gombieX = Abs(Hitbox.X);
            int gombieY = Abs(Hitbox.Y);
            if (playerX > gombieX)
            {
                x = playerX - gombieX;
            }
            else if (playerX < gombieX)
            {
                x = gombieX - playerX;
            }

            if (playerY > gombieY)
            {
                y = playerY - gombieY;
            }
            else if (playerY < gombieY)
            {
                y = gombieY - playerY;
            }
            direction.X = Sign(playerX - gombieX);
            direction.Y = Sign(playerY - gombieY);
            if (player.Hitbox.Y == Hitbox.Y && player.Hitbox.X == Hitbox.X)
            {
                x = player.Hitbox.X - Hitbox.X;
                y = player.Hitbox.Y - Hitbox.Y;
            }
            if (Math.Abs(x) + Math.Abs(y) != 0)
            {
                float value = (float)speed / (x + y);
                Speed.X = (float)x * (float)value * direction.X;
                Speed.Y = (float)y * (float)value * direction.Y;
            }
            else
            { 
                Speed = new Vector2(0, 0);
            }

            Position = new Point((int)(Position.X + Speed.X), (int)(Position.Y + Speed.Y));

            Rotation = ((float)Math.Atan2(player.Hitbox.Y-Hitbox.Y, player.Hitbox.X-Hitbox.X) + (float)Math.PI/2);
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.RotatedDraw(spiteBatch, Rotation, Frames[currentFrame]);
        }
        public bool isHit(Bullet bullet)
        {
            if(Hitbox.Intersects(bullet.Hitbox))
            {
                return true; 
            }
            return false;
        }
    }
}