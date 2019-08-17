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
    class EnemyCollision : Collision
    {
        public EnemyCollision(Blok[,] blokArray, List<Enemies> _enemy) : base(blokArray, _enemy)
        {
        }

        public override void CheckCollision()
        {
            foreach (Enemies enemy in enemies)
            {
                //Console.WriteLine("enemy check?");
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
                            //Console.WriteLine("grond enemy");
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
                    //Console.WriteLine("onplat enemy");
                }
            }

        }
    }
    }
