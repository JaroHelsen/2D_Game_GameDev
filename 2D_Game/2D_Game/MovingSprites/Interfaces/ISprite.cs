using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_Game.MovingSprites
{
    public interface ISprite
    {
        /// <summary>
        /// Interface for the sprite abstract class
        /// </summary>
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