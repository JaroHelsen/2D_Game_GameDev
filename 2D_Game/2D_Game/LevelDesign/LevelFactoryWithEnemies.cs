using _2D_Game.LevelDesign.Interfaces;
using _2D_Game.Main;
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
    public abstract class LevelFactoryWithEnemies: LevelFactory, ILevelfactory_Enemies
    {
        public List<Enemies> enemies;
        protected EnemyCreator enemyCreator = new EnemyCreator();
        protected Collision enemyCollisionChecker;

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

        public void ReturnEnemiesToPlaces()
        {
            foreach (Enemies enemy in enemies)
            {
                enemy.Relocate();
            }
        }

        public override void ResetLevel()
        {
            LevelEnd = false;
            ReturnEnemiesToPlaces();
        }

        public override void EndOfLevel(ContentManager content)
        {
            LevelEnd = true;
            enemies.Clear();
            CreateEnemies(content);
        }

        public abstract void CreateEnemies(ContentManager content);
    }
}
