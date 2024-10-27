using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shoot
{
    internal class Bullet : Sprite
    {
        Rectangle scource = new Rectangle(1, 1, 790, 350);
        Vector2 Speed = new Vector2(0, 0);
        int speed = 20;
        public Bullet(Point position, Vector2 scale, Texture2D image, Point origin, Point tgt)
            : base(position, scale, image)
        {
            Origin = new Point(90, 173);
            Position = origin;
            int x = tgt.X - origin.X;
            int y = tgt.Y - origin.Y;
            if (Math.Abs(x) + Math.Abs(y) != 0)
            {
                float value = (float)speed / (Math.Abs(x) + Math.Abs(y));
                Speed.X = (float)x * (float)value;
                Speed.Y = (float)y * (float)value;
            }
            Rotation = (float)Math.Atan2(y, x) + (float)Math.PI / 2;
        }
        public void Update()
        {
            Position.X += (int)Speed.X;
            Position.Y += (int)Speed.Y;
        }
        public override void Draw(SpriteBatch spiteBatch)
        {
            base.RotatedDraw(spiteBatch, Rotation, scource);
        }
    }
}
