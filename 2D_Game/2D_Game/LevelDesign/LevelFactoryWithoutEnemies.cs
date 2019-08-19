using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_Game.LevelDesign
{
    public abstract class LevelFactoryWithoutEnemies : LevelFactory
    {

        #region Methods
        /// <summary>
        /// Overrides the LevelFactory method DrawWorld from its super LevelFactory.
        /// Draws the blocks for the level that calls it.
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
        }

        /// <summary>
        /// Overrides the LevelFactory method DrawWorld from its super LevelFactory.
        /// Checks for collisions for the hero inside the level.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="hero"></param>
        /// <param name="content"></param>
        public override void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content)
        {
            hero.Update(gameTime);

            heroCollisionChecker.CheckCollision();
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
        /// Called when the end of the level has been reached.
        /// </summary>
        /// <param name="content"></param>
        public override void EndOfLevel(ContentManager content)
        {
            LevelEnd = true;
        }

        /// <summary>
        /// Resets the level so that levelend is false.
        /// </summary>
        public override void ResetLevel()
        {
            LevelEnd = false;
        }
        #endregion
    }
}
