﻿using _2D_Game.Main;
using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.LevelDesign
{
    class Level1: LevelFactory
    {
        /// <summary>
        /// Constructor for the level 1.
        /// The tilearray is there so we can create the level with the create- and drawworld methods from the abstract level class
        /// </summary>
        /// <param name="_content"></param>
        /// <param name="myHero"></param>
        public Level1(ContentManager _content, Hero myHero) : base(myHero)
        {
            enemy = new Enemies(new Vector2(100, 100), _content.Load<Texture2D>("Jumping"));
            enemy.BootsOnTheGround = true;
            tileArray = new byte[,]
            {
                {2,1,1,1,1,1,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,0,3,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,1,1,1,1},
                {0,0,0,2,1,1,1,1},
                {0,0,2,1,1,1,1,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,2,0,0,2},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,2,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,0,3,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,2,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,2,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,2,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,2,1,1,1,1},
                {0,0,2,1,1,1,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,25,2,1},
                {2,1,1,1,1,1,1,1},
            };

            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];
            collisionChecker = new Collision(thisHero, blokArray, enemy);
        }
    }
}
