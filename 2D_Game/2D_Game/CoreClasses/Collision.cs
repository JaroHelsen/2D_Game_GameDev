using _2D_Game.LevelDesign;
using _2D_Game.MovingSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.Main
{
    class Collision
    {
        #region Variables
        Blok[,] blokken;
        Hero thisHero;
        Enemies[] enemies;

        public bool xMovement = false;
        public bool onPlat = false;
        public bool Auwch = false;

        private Game1 game;
        #endregion

        #region Constructor
        public Collision(Hero _hero, Blok[,] blokArray, Enemies[] _enemy)
        {
            thisHero = _hero;
            game = new Game1();
            blokken = blokArray;
            enemies = _enemy;
        }
        #endregion

        #region CollisionCheck
        /// <summary>
        /// Checks if there is any collision between the hero and a blok object.
        /// If so the hero will be propelled back to it's last position.
        /// If OnPlat is set to true once, because one Blok object has it's onPlatform set to true, the hero.bootsontheground will be set to true so that
        /// the program knows hero is standing on the ground and not jumping/falling.
        /// Auwch is used so that we know if the hero is touching/colliding with a Blok object with ID 3.
        /// If so the player dies and the HasDied method will be called to respawn the player.
        /// </summary>
        public void CheckCollision()
        {
            Console.WriteLine("word ik opgeroepen?");
            onPlat = false;
            Auwch = false;
            //thisHero.BootsOnTheGround = false;
            foreach (Blok blok in blokken)
            {

                xMovement = false;
                if (blok != null)
                {
                    if (blok.Id != 3 && blok.Id != 25)
                    {
                        blok.OnPLatform = false;
                        //Check for collision from the left side of the hero (thus he is walking to the left)
                        if (thisHero.CollisionRectangle.Left + thisHero.Velocity.X < blok.CollisionRectangle.Right && thisHero.CollisionRectangle.Right > blok.CollisionRectangle.Right && thisHero.CollisionRectangle.Bottom < blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Bottom > blok.CollisionRectangle.Top && thisHero.input.Left == true)
                        {
                            thisHero.Position.X += 6;
                            xMovement = true;
                        }
                        //Check for collision from the right side of the hero (thus he is walking to the right)
                        if (thisHero.CollisionRectangle.Right + thisHero.Velocity.X > blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left < blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Bottom < blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Bottom > blok.CollisionRectangle.Top && thisHero.input.Right == true)
                        {
                            thisHero.Position.X -= 6;
                            xMovement = true;
                        }
                        //Check for collision with hero and a blok underneath it
                        if (thisHero.CollisionRectangle.Bottom + 25 >= blok.CollisionRectangle.Top && thisHero.CollisionRectangle.Top < blok.CollisionRectangle.Top && ((thisHero.CollisionRectangle.Left + 15 >= blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left + 15 <= blok.CollisionRectangle.Right) || (thisHero.CollisionRectangle.Right - 15 >= blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Right - 15 <= blok.CollisionRectangle.Right)))
                        {
                            thisHero.Position.Y = blok.CollisionRectangle.Top - thisHero.CollisionRectangle.Height - 20;
                            blok.OnPLatform = true;
                        }
                        //Check for collision betweenhero and blok on top of it
                        if (thisHero.CollisionRectangle.Top + thisHero.Velocity.Y < blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Bottom > blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Right > blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left < blok.CollisionRectangle.Right && thisHero.HasJumped == true)
                        {
                            thisHero.Position.Y -= thisHero.Velocity.Y - 3;
                        }
                    }
                    else if (blok.Id == 3)
                    {
                        if (thisHero.CollisionRectangle.Intersects(blok.CollisionRectangle))
                        {
                            blok.OnPLatform = false;
                            Auwch = true;
                        }
                    }
                    else if (blok.Id == 25)
                    {
                        if (thisHero.CollisionRectangle.Intersects(blok.CollisionRectangle))
                        {
                            game.Exit();
                        }
                    }

                }
            }
            foreach (Blok blok in blokken)
            {
                if (blok != null)
                {
                    if (blok.OnPLatform)
                    {
                        Console.WriteLine("grond");
                        thisHero.BootsOnTheGround = true;
                        onPlat = true;
                        blok.OnPLatform = false;
                    }
                }

            }
            if (!onPlat)
            {
                thisHero.HasJumped = true;
                thisHero.BootsOnTheGround = false;
                Console.WriteLine("onplat");
            }
            if (Auwch)
            {
                thisHero.Health -= 25;
                Console.WriteLine(thisHero.Health);
                if (thisHero.Health <= 0)
                {
                    thisHero.HasDied();
                }
                Auwch = false;
            }
        }

        public void EnemyCollisionCheck()
        {
            foreach (Enemies enemy in enemies)
            {
                Console.WriteLine("enemy check?");
                Console.WriteLine(enemy.HasJumped);
                onPlat = false;
                Auwch = false;
                foreach (Blok blok in blokken)
                {

                    xMovement = false;
                    if (blok != null)
                    {
                        if (blok.Id != 3 && blok.Id != 25)
                        {
                            blok.OnPLatform = false;
                            //Check for collision from the left side of the hero(thus he is walking to the left)
                            if (enemy.CollisionRectangle.Left + enemy.Velocity.X < blok.CollisionRectangle.Right && enemy.CollisionRectangle.Right > blok.CollisionRectangle.Right && enemy.CollisionRectangle.Bottom < blok.CollisionRectangle.Bottom && enemy.CollisionRectangle.Bottom > blok.CollisionRectangle.Top)// && thisHero.input.Left == true)
                            {
                                enemy.Position.X += 6;
                                xMovement = true;
                            }
                            //Check for collision from the right side of the hero (thus he is walking to the right)
                            if (enemy.CollisionRectangle.Right + enemy.Velocity.X > blok.CollisionRectangle.Left && enemy.CollisionRectangle.Left < blok.CollisionRectangle.Left && enemy.CollisionRectangle.Bottom < blok.CollisionRectangle.Bottom && enemy.CollisionRectangle.Bottom > blok.CollisionRectangle.Top)// && thisHero.input.Right == true)
                            {
                                enemy.Position.X -= 6;
                                xMovement = true;
                            }
                            //Check for collision with hero and a blok underneath it
                            if (enemy.CollisionRectangle.Bottom + 25 >= blok.CollisionRectangle.Top && enemy.CollisionRectangle.Top < blok.CollisionRectangle.Top && ((enemy.CollisionRectangle.Left + 15 >= blok.CollisionRectangle.Left && enemy.CollisionRectangle.Left + 15 <= blok.CollisionRectangle.Right) || (enemy.CollisionRectangle.Right - 15 >= blok.CollisionRectangle.Left && enemy.CollisionRectangle.Right - 15 <= blok.CollisionRectangle.Right)))
                            {
                                enemy.Position.Y = blok.CollisionRectangle.Top - enemy.CollisionRectangle.Height - 20;
                                blok.OnPLatform = true;
                            }
                            //Check for collision betweenhero and blok on top of it
                            if (enemy.CollisionRectangle.Top + enemy.Velocity.Y < blok.CollisionRectangle.Bottom && enemy.CollisionRectangle.Bottom > blok.CollisionRectangle.Bottom && enemy.CollisionRectangle.Right > blok.CollisionRectangle.Left && enemy.CollisionRectangle.Left < blok.CollisionRectangle.Right && enemy.HasJumped == true)
                            {
                                enemy.Position.Y -= enemy.Velocity.Y - 3;
                            }
                        }
                        else if (blok.Id == 3)
                        {
                            if (enemy.CollisionRectangle.Intersects(blok.CollisionRectangle))
                            {
                                blok.OnPLatform = false;
                                Auwch = true;
                            }
                        }

                    }
                }
                foreach (Blok blok in blokken)
                {
                    if (blok != null)
                    {
                        if (blok.OnPLatform)
                        {
                            Console.WriteLine("grond enemy");
                            enemy.BootsOnTheGround = true;
                            onPlat = true;
                            blok.OnPLatform = false;
                        }
                    }

                }
                if (!onPlat)
                {
                    enemy.HasJumped = true;
                    enemy.BootsOnTheGround = false;
                    Console.WriteLine("onplat enemy");
                }
            }
            
        }
        #endregion
    }
}
