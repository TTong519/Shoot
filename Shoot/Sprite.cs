using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    internal class Sprite
    {
        public virtual Rectangle Hitbox => new Rectangle(Position, new Point((int)(Image.Width * Scale.X), (int)(Image.Height * Scale.Y)));
        public Texture2D Image;
        public Point Position;
        protected Vector2 Scale;
        protected float Rotation;
        protected Point Origin;
        public Sprite(Point position, Vector2 scale, Texture2D image)
        {
            Position = position;
            Scale = scale;
            Image = image;
        }
        public virtual void Draw(SpriteBatch spiteBatch)
        {
            spiteBatch.Draw(Image, Hitbox, Color.White);
        }
        public virtual void RotatedDraw(SpriteBatch spiteBatch, float rotation)
        {
            spiteBatch.Draw(Image, Hitbox, null, Color.White, rotation, Origin.ToVector2(), SpriteEffects.None, 0);
        }
    }
}
