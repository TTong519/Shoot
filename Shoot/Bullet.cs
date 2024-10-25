using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Shoot
{
    internal class Bullet : Sprite
    {
        public Bullet(Point position, Vector2 scale, Texture2D image)
            : base(position, scale, image)
        {
            Origin = new Point(90, 173);
        }
    }
}
