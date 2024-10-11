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
    }
}
