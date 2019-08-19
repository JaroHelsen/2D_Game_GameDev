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
        /// <summary>
        /// Interface for the hero class
        /// </summary>
        #region Properties
        int TimesDied { get; set; }
        Boolean HasJumped { get; set; }
        Boolean TooManyDeaths { get; set; }
        Rectangle CollisionRectangle { get; set; }
        #endregion
    }
}
