using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    internal class ScuffedGombie:AnimatedSprite
    {
        int xspeed;
        int yspeed;
        float rotation;
        const int speed = 5;
        readonly Point origin = new Point(90, 173);
        public ScuffedGombie(Point position, Vector2 scale, Texture2D image, Rectangle[] frames, int frameDelay) : base(position, scale, image, frames, frameDelay)
        {

        }
        public void Update(GameTime gameTime, Player player)
        {
            base.Update(gameTime);
            int x = player.Hitbox.X - Hitbox.X;
            int y = player.Hitbox.Y - Hitbox.Y;
            float value = speed / (x + y);
            xspeed = (int)(x * value);
            yspeed = (int)(y * value);
            Position = new Point(Position.X + xspeed, Position.Y + xspeed);
            float hyp = (float)Math.Sqrt((x^2)+(y^2));
            rotation = Math.Asin((float)(y/hyp));
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.RotatedDraw(spiteBatch, );
        }
    }
}
