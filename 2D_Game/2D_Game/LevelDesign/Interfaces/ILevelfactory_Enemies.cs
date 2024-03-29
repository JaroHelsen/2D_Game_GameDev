﻿using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.LevelDesign.Interfaces
{
    interface ILevelfactory_Enemies
    {
        /// <summary>
        /// Interface for the Enemies level factory
        /// </summary>
        /// <param name="content"></param>
        void CreateEnemies(ContentManager content);
        void ReturnEnemiesToPlaces();
    }
}
