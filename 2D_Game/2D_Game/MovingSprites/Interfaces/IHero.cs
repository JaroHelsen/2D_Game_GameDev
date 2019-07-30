using _2D_Game.Animations;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites.Interfaces
{
    interface IHero
    {
        #region Properties
        /// <summary>
        /// Properties are found here.
        /// </summary>
        Boolean HasJumped { get; set; }
        Rectangle CollisionRectangle { get; set; }

        AnimationMotion HeroAnimation { get; set; }
        #endregion

        #region Methods
        void HasDied();

        #endregion

    }
}
