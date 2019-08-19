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
        #region Variables
        public List<Enemies> enemies;
        protected EnemyCreator enemyCreator = new EnemyCreator();
        protected Collision enemyCollisionChecker;
        #endregion

        #region Methods
        /// <summary>
        /// Overrides the LevelFactory method DrawWorld from its super LevelFactory.
        /// Draws the blocks and enemies for the level that calls it.
        /// </summary>
        /// <param name="spriteBatch"></param>
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

        /// <summary>
        /// Overrides the LevelFactory method DrawWorld from its super LevelFactory.
        /// Checks for collisions for the enemies and the hero inside the level.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="hero"></param>
        /// <param name="content"></param>
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

        /// <summary>
        /// Resets the enemy locations to how they started.
        /// </summary>
        public void ReturnEnemiesToPlaces()
        {
            foreach (Enemies enemy in enemies)
            {
                enemy.Relocate();
            }
        }

        /// <summary>
        /// Resets the level so that levelend is false and the method ReturnEnemiesToPlaces is called.
        /// </summary>
        public override void ResetLevel()
        {
            LevelEnd = false;
            ReturnEnemiesToPlaces();
        }

        /// <summary>
        /// Called when the end of the level has been reached.
        /// </summary>
        /// <param name="content"></param>
        public override void EndOfLevel(ContentManager content)
        {
            LevelEnd = true;
            enemies.Clear();
            CreateEnemies(content);
        }

        /// <summary>
        /// Abstract method so that each level can have it's variation on this.
        /// </summary>
        /// <param name="content"></param>
        public abstract void CreateEnemies(ContentManager content);
        #endregion
    }
}
