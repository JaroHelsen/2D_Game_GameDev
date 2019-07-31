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
        #region Properties
        public Animation CurrentAnimation { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// The constructor for the AnimationMotion class.
        /// Creates a new Animation class object and sets the AantalBewegingenPerSeconde to a default of 8.
        /// </summary>
        public AnimationMotion()
        {
            CurrentAnimation = new Animation();

            CurrentAnimation.AantalBewegingenPerSeconde = 8;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds an animation to the CurrentAnimation property.
        /// When we create a new Animation it is still empty. 
        /// AddFrames adds a specific amount of frames (using max as a variable). 
        /// _texture is the full sprite texture that gets send through. 
        /// Using max on the texture cuts the texture in pieces so that each animation is the same widt and height.
        /// </summary>
        /// <param name="_texture"></param>
        /// <param name="max"></param>
        public void AddAnimation(Texture2D _texture, int max)
        {
            int _totalHeight = 0;
            for (int i = 0; i < max; i++)
            {
                _totalHeight = i * (_texture.Height / max);
                CurrentAnimation.AddFrame(new Rectangle(0, _totalHeight, _texture.Width, _texture.Height / max));
            }
        }

        /// <summary>
        /// Updates the animation so that it moves goes through the different parts/frames.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
        }

        #endregion
    }
}
