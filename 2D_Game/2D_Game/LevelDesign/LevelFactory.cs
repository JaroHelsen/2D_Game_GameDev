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
    class LevelFactory
    {
        ContentManager content;
        Collision collisionChecker;
        public Hero thisHero;
        public Texture2D GroundTexture { get; set; }
        public Texture2D CrateTexture { get; set; }
        private byte[,] tileArray = new byte[,]
        {
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,1,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,1,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,1,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
            {0,0,0,0,0,0,1,1},
        };

        private Blok[,] blokArray;

        public LevelFactory(ContentManager _content)
        {
            content = _content;
            thisHero = new Hero(_content, new Vector2(50, 100));
            thisHero.input = new BedieningPijltjes();
            GroundTexture = content.Load<Texture2D>("Tile/2");
            CrateTexture = content.Load<Texture2D>("Objects/Crate");
            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];
            collisionChecker = new Collision(thisHero, blokArray);
        }

        public void CreateLevel()
        {
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    if (tileArray[i, j] == 1)
                    {
                        blokArray[i, j] = new Blok(GroundTexture, new Vector2(128 * i, 128 * j));
                    }
                    else if (tileArray[i, j] == 2)
                    {
                        blokArray[i, j] = new Blok(CrateTexture, new Vector2(128 * i, 128 * j));
                    }
                    else
                    {
                        blokArray[i, j] = null;
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
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

            thisHero.Draw(spriteBatch);
        }

        public void CheckForCollision(GameTime gameTime)
        {
            thisHero.Update(gameTime);
            collisionChecker.CheckCollision();
        }
    }
}
