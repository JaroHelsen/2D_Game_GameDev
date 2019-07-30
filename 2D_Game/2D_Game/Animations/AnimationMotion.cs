using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.Animations
{
    public class AnimationMotion
    {
        public Animation CurrentAnimation { get; set; }

        public AnimationMotion()
        {
            CurrentAnimation = new Animation();
            CurrentAnimation.AantalBewegingenPerSeconde = 8; //TODO: Aanpassen naar constructor
        }

        #region Methods
        public void AddAnimation(Texture2D _texture, int max)
        {
            int totalHeight = 0;
            for (int i = 0; i < max; i++)
            {
                totalHeight = i * (_texture.Height / max);
                CurrentAnimation.AddFrame(new Rectangle(0, totalHeight, _texture.Width, _texture.Height / max));
            }
        }

        public void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
        }
        #endregion
    }
}
