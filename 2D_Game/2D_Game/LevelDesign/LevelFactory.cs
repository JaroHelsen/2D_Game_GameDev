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
        //ContentManager content;
        protected Collision heroCollisionChecker;
        public Texture2D GroundTexture { get; set; }
        public Texture2D CrateTexture { get; set; }
        public Boolean LevelEnd { get; set; }
        protected byte[,] tileArray;

        protected Blok[,] blokArray;

        public LevelFactory()
        {
            LevelEnd = false;
        }

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
                        blokArray[i, j] = new Blok(content.Load<Texture2D>("Objects/Crate"), new Vector2(128 * i, 128 * j));
                        blokArray[i, j].Id = 25;
                    }
                    else
                    {
                        blokArray[i, j] = null;
                    }
                }
            }
        }

        //public void DestroyLevel()
        //{
        //    Array.Clear(blokArray, 0, blokArray.Length);
        //    Array.Clear(tileArray, 0, tileArray.Length);
        //    enemies.Clear();

        //}

        public abstract void DrawWorld(SpriteBatch spriteBatch);
        //public void DrawWorld(SpriteBatch spriteBatch)
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
        //    foreach (Enemies enemy in enemies)
        //    {
        //        enemy.Draw(spriteBatch);
        //    }
        //}

        public abstract void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content);
        //public void CheckForCollision(GameTime gameTime, Hero hero, ContentManager content)
        //{
        //    hero.Update(gameTime);
        //    foreach (Enemies enemy in enemies)
        //    {
        //        enemy.Update(gameTime);
        //    }

        //    heroCollisionChecker.CheckCollision();
        //    enemyCollisionChecker.CheckCollision();

        //    for (int i = enemies.Count -  1 ; i >= 0 ; i--)
        //    {
        //        if (enemies[i].Health == 0)
        //        {
        //            enemies[i].Position.X = -1000;
        //        }
        //    }
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

        public abstract void ResetLevel();

        public abstract void EndOfLevel(ContentManager content);

        
    }
}
