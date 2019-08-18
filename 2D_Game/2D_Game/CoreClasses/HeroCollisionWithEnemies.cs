using _2D_Game.LevelDesign;
using _2D_Game.Main;
using _2D_Game.MovingSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.CoreClasses
{
    class HeroCollisionWithEnemies : Collision
    {
        public HeroCollisionWithEnemies(Hero _hero, Blok[,] blokArray, List<Enemies> _enemy) : base(_hero, blokArray, _enemy)
        {
        }

        public override void CheckCollision()
        {
            onPlat = false;
            Auwch = false;
            foreach (Blok blok in blokken)
            {

                xMovement = false;
                if (blok != null)
                {
                    if (blok.Id != 25)
                    {
                        blok.OnPLatform = false;
                        //Check for collision from the left side of the hero (thus he is walking to the left)
                        if (thisHero.CollisionRectangle.Left + thisHero.Velocity.X < blok.CollisionRectangle.Right && thisHero.CollisionRectangle.Right > blok.CollisionRectangle.Right && thisHero.CollisionRectangle.Bottom < blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Bottom > blok.CollisionRectangle.Top && thisHero.input.Left == true)
                        {
                            if (blok.Id == 3)
                            {
                                blok.OnPLatform = false;
                                Auwch = true;
                            }
                            else
                            {
                                thisHero.Position.X += 6;
                                xMovement = true;
                            }
                        }
                        //Check for collision from the right side of the hero (thus he is walking to the right)
                        if (thisHero.CollisionRectangle.Right + thisHero.Velocity.X > blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left < blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Bottom < blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Bottom > blok.CollisionRectangle.Top && thisHero.input.Right == true)
                        {
                            if (blok.Id == 3)
                            {
                                blok.OnPLatform = false;
                                Auwch = true;
                            }
                            else
                            {
                                thisHero.Position.X -= 6;
                                xMovement = true;
                            }
                        }
                        //Check for collision with hero and a blok underneath it
                        if (thisHero.CollisionRectangle.Bottom + 25 >= blok.CollisionRectangle.Top && thisHero.CollisionRectangle.Top < blok.CollisionRectangle.Top && ((thisHero.CollisionRectangle.Left + 15 >= blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left + 15 <= blok.CollisionRectangle.Right) || (thisHero.CollisionRectangle.Right - 15 >= blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Right - 15 <= blok.CollisionRectangle.Right)))
                        {
                            if (blok.Id == 3)
                            {
                                blok.OnPLatform = false;
                                Auwch = true;
                            }
                            else
                            {
                                thisHero.Position.Y = blok.CollisionRectangle.Top - thisHero.CollisionRectangle.Height - 20;
                                blok.OnPLatform = true;
                            }
                        }
                        //Check for collision betweenhero and blok on top of it
                        if (thisHero.CollisionRectangle.Top + thisHero.Velocity.Y < blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Bottom > blok.CollisionRectangle.Bottom && thisHero.CollisionRectangle.Right > blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left < blok.CollisionRectangle.Right && thisHero.HasJumped == true)
                        {
                            if (blok.Id == 3)
                            {
                                blok.OnPLatform = false;
                                Auwch = true;
                            }
                            else
                            {
                                thisHero.Position.Y -= thisHero.Velocity.Y - 3;
                            }
                        }
                    }
                    else if (blok.Id == 25)
                    {
                        if (thisHero.CollisionRectangle.Intersects(blok.CollisionRectangle))
                        {
                            blok.FinishLine = true;
                            Console.WriteLine("Da werkt?");
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
                        thisHero.BootsOnTheGround = true;
                        onPlat = true;
                        blok.OnPLatform = false;
                    }
                }

            }
            foreach (Enemies enemy in enemies)
            {
                //Check for collision with hero and a blok underneath it
                if (thisHero.CollisionRectangle.Bottom + 25 >= enemy.CollisionRectangle.Top && thisHero.CollisionRectangle.Top < enemy.CollisionRectangle.Top && ((thisHero.CollisionRectangle.Left + 15 >= enemy.CollisionRectangle.Left && thisHero.CollisionRectangle.Left + 15 <= enemy.CollisionRectangle.Right) || (thisHero.CollisionRectangle.Right - 15 >= enemy.CollisionRectangle.Left && thisHero.CollisionRectangle.Right - 15 <= enemy.CollisionRectangle.Right)) && thisHero.HasJumped)
                {
                    enemy.HasDied();
                    Console.WriteLine("GOT EMMMMMMMMM");
                }
                else if (thisHero.CollisionRectangle.Intersects(enemy.CollisionRectangle))
                {
                    Console.WriteLine("HELP IK BEN GERAAKT");
                    Auwch = true;
                }
            }

            if (!onPlat)
            {
                thisHero.HasJumped = true;
                thisHero.BootsOnTheGround = false;
            }
            if (Auwch)
            {
                thisHero.HasDied();
                Auwch = false;
            }
        }
    }
}
