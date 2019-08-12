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
    abstract class LevelFactory
    {
        //ContentManager content;
        protected Collision collisionChecker;
        public Hero thisHero;
        public Enemies[] enemies = new Enemies[2];
        public Texture2D GroundTexture { get; set; }
        public Texture2D CrateTexture { get; set; }
        protected byte[,] tileArray;

        protected Blok[,] blokArray;

        public LevelFactory(Hero myHero)
        {
            //content = _content;
            thisHero = myHero;
            //blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];
            //collisionChecker = new Collision(thisHero, blokArray);
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
                    //else if (tileArray[i, j] == 25)
                    //{
                    //    blokArray[i, j] = new Blok(content.Load<Texture2D>("Objects/Crate"), new Vector2(128 * i, 128 * j));
                    //    blokArray[i, j].Id = 25;
                    //}
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
            foreach (Enemies enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            
            //thisHero.Draw(spriteBatch);
        }

        public void CheckForCollision(GameTime gameTime, Hero hero, Enemies _enemies)
        {
            hero.Update(gameTime);
            foreach (Enemies enemy in enemies)
            {
                enemy.Update(gameTime);
            }
            
            collisionChecker.CheckCollision();
            collisionChecker.EnemyCollisionCheck();
        }
    }
}
