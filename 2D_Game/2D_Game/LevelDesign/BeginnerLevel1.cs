using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2D_Game.CoreClasses;
using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_Game.LevelDesign
{
    class BeginnerLevel1 : LevelFactoryWithoutEnmies
    {
        #region Constructor
        /// <summary>
        /// Constructor for the class.
        /// Initializes and creates enemies, which type of tile is used where and starts the collision for the hero.
        /// </summary>
        /// <param name="_content"></param>
        /// <param name="myHero"></param>
        public BeginnerLevel1(ContentManager _content, Hero myHero)
        {
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
                {0,0,2,0,0,0,3,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,2,0,0,2},
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
                {0,0,0,0,0,2,1,1},
                {0,0,0,2,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,0,0,3,1},
                {0,0,0,0,2,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,2,1,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,2,0,2,1},
                {0,0,0,2,1,0,2,1},
                {0,0,2,1,0,0,2,1},
                {0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,2},
                {0,2,0,0,0,0,0,2},
                {0,0,0,0,2,0,0,2},
                {0,0,0,0,0,0,2,1},
                {0,0,0,2,0,0,2,1},
                {0,0,0,0,0,0,2,1},
                {0,0,0,0,0,0,2,1},
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
            heroCollisionChecker = new HeroCollision(myHero, blokArray);
        }
        #endregion

        //public override void DrawWorld(SpriteBatch spriteBatch)
        //{
        //    for (int i = 0; i < tileArray.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < tileArray.GetLength(1); j++)
        //        {
        //            if (blokArray[i, j] != null)
        //            {
        //                blokArray[i, j].Draw(spriteBatch);
        //            }
        //        }
        //    }
        //}

        //public override void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content)
        //{
        //    hero.Update(gameTime);

        //    heroCollisionChecker.CheckCollision();
        //    foreach (Blok blok in blokArray)
        //    {
        //        if (blok != null)
        //        {
        //            if (blok.FinishLine)
        //            {
        //                Console.WriteLine("This is the end");
        //                Console.WriteLine("-------------------------------------------------------------------------");
        //                Console.WriteLine("");
        //                EndOfLevel(content);
        //            }
        //        }

        //    }
        //}

        //public override void EndOfLevel(ContentManager content)
        //{
        //    LevelEnd = true;
        //}

        //public override void ResetLevel()
        //{
        //    LevelEnd = false;
        //}
        public override void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void DrawWorld(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void EndOfLevel(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void ResetLevel()
        {
            throw new NotImplementedException();
        }
    }
}
