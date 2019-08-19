using _2D_Game.Controls;
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
    public abstract class LevelFactory
    {
        #region Properties
        public Texture2D GroundTexture { get; set; }
        public Texture2D CrateTexture { get; set; }
        public Boolean LevelEnd { get; set; }
        #endregion

        #region Variables
        protected Collision heroCollisionChecker;
        protected byte[,] tileArray;
        protected Blok[,] blokArray;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the class.
        /// Sets the LevelEnd to false so that there is no uncertainty when the level is created. This is the same for all levels.
        /// </summary>
        public LevelFactory()
        {
            LevelEnd = false;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the level.
        /// All the different kind of bloks will be generated and loaded (textures and position)
        /// </summary>
        /// <param name="content"></param>
        public void CreateLevel(ContentManager content)
        {
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    if (tileArray[i, j] == 1)
                    {
                        blokArray[i, j] = new Blok(content.Load<Texture2D>("png/Tile/5"), new Vector2(128 * i, 128 * j));
                        blokArray[i, j].Id = 1;
                    }
                    else if (tileArray[i, j] == 2)
                    {
                        blokArray[i, j] = new Blok(content.Load<Texture2D>("png/Tile/2"), new Vector2(128 * i, 128 * j));
                        blokArray[i, j].Id = 1;
                    }
                    else if (tileArray[i, j] == 3)
                    {
                        blokArray[i, j] = new Blok(content.Load<Texture2D>("png/water"), new Vector2(128 * i, 128 * j));
                        blokArray[i, j].Id = 3;
                    }
                    else if (tileArray[i,j] == 4)
                    {
                        blokArray[i, j] = new Blok(content.Load<Texture2D>("png/water_bottom"), new Vector2(128 * i, 128 * j));
                        blokArray[i, j].Id = 4;
                    }
                    else if (tileArray[i, j] == 25)
                    {
                        blokArray[i, j] = new Blok(content.Load<Texture2D>("Objects/Sign"), new Vector2(128 * i, 128 * j + 50));
                        blokArray[i, j].Id = 25;
                    }
                    else
                    {
                        blokArray[i, j] = null;
                    }
                }
            }
        }

        /// <summary>
        /// DrawWorld, CheckForCollision, ResetLevel and EndOfLevel are all abstract because they differ for worlds with and without enemies.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void DrawWorld(SpriteBatch spriteBatch);

        public abstract void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content);

        public abstract void ResetLevel();

        public abstract void EndOfLevel(ContentManager content);
        #endregion

    }
}
