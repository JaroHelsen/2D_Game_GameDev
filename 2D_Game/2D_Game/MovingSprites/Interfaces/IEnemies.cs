using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites.Interfaces
{
    interface IEnemies
    {
        /// <summary>
        /// Interface for the enemy class
        /// </summary>
        Vector2 Relocator { get; set; }
    }
}
