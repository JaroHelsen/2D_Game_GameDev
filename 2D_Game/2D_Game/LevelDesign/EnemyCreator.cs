using _2D_Game.MovingSprites;
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
        public List<Enemies> GeneratedEnemies { get; set; }
        private Random rand;
        public List<Enemies> GenerateEnemies(int aantal, Texture2D texture, Vector2 position, int randomMax)
        {
            rand = new Random();
            GeneratedEnemies = new List<Enemies>();

            for (int i = 0; i < aantal; i++)
            {
                position.X = rand.Next(820, randomMax);
                
                GeneratedEnemies.Add(new Enemies(texture, position, 150));
            }
            return GeneratedEnemies;
        }
    }
}
