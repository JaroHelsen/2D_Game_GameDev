using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2D_Game.CoreClasses;
using _2D_Game.LevelDesign.Interfaces;
using _2D_Game.Main;
using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_Game.LevelDesign
{
    class Level2 : LevelFactoryWithEnemies, ILevelfactory_Enemies
    {
        public Level2(ContentManager _content, Hero myHero )
        {

            enemies = new List<Enemies>();
            CreateEnemies(_content);
            tileArray = new byte[,]
            {
                {2,1,1,1,1,1,1,1},
                {0,0,2,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {2,1,1,1,0,0,2,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,2,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,2,1,1,1,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,2,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,0,3,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,2,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,2,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
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
                {0,0,0,0,2,0,2,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,2,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,0,3,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,2,0,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,2,1,0,0,0,2},
                {0,0,2,0,0,0,0,2},
                {0,0,2,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,2,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,2,1,1,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,2,1},
                {0,0,2,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,2,0,0,2,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,2,0,2,1},
                {0,0,0,0,2,0,0,2},
                {0,0,0,0,2,0,2,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,2,0,0,0,3,1},
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
            heroCollisionChecker = new HeroCollisionWithEnemies(myHero, blokArray, enemies);
            enemyCollisionChecker = new EnemyCollision(blokArray, enemies);
        }

        public override void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    if (blokArray[i, j] != null)
                    {
                        blokArray[i, j].Draw(spriteBatch);
                    }
                }
            }
            foreach (Enemies enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public override void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content)
        {
            hero.Update(gameTime);
            foreach (Enemies enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            heroCollisionChecker.CheckCollision();
            enemyCollisionChecker.CheckCollision();

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].Health == 0)
                {
                    enemies[i].Position.X = -1000;
                }
            }
            foreach (Blok blok in blokArray)
            {
                if (blok != null)
                {
                    if (blok.FinishLine)
                    {
                        Console.WriteLine("This is the end");
                        Console.WriteLine("-------------------------------------------------------------------------");
                        Console.WriteLine("");
                        EndOfLevel(content);
                    }
                }

            }
        }

        public override void CreateEnemies(ContentManager content)
        {
            enemies = enemyCreator.GenerateEnemies(30, content.Load<Texture2D>("EnemyWalker"), new Vector2(0, -100), 12301);
            foreach (Enemies enemy in enemies)
            {
                enemy.Relocator = enemy.Position;
            }
        }
    }
}
