using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites.Interfaces
{
    interface ISprite
    {
        Texture2D SpriteTexture { get; set; }
        bool BootsOnTheGround { get; set; }
        int Health { get; set; }
        bool HasJumped { get; set; }


        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void HasDied();
        void Relocate();
    }
}
