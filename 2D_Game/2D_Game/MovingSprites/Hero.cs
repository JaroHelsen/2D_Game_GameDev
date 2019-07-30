using _2D_Game.Animations;
using _2D_Game.MovingSprites.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites
{
    public class Hero :  Sprite, IHero
    {
        public bool HasJumped { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public AnimationMotion HeroAnimation { get; set; }

        public Hero(Vector2 _position) : base(_position)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void HasDied()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
