﻿using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.LevelDesign
{
    class EnemyCreator
    {
        public Enemies[] GeneratedEnemies { get; set; }
        private Random rand;
        public Enemies[] GenerateEnemies(int aantal, Texture2D texture, Vector2 position)
        {
            rand = new Random();
            GeneratedEnemies = new Enemies[aantal];
            
            for (int i = 0; i < aantal; i++)
            {
                position.X = rand.Next(100, 500);
                GeneratedEnemies[i] = new Enemies(texture, position, 150);
            }
            return GeneratedEnemies;
        }
    }
}
