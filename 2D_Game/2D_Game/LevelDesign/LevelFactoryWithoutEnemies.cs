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

        public override void EndOfLevel(ContentManager content)
        {
            LevelEnd = true;
        }

        public override void ResetLevel()
        {
            LevelEnd = false;
        }
    }
}
