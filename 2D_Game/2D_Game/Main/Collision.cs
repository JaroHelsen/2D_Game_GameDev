using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.Main
{
    class Collision
    {
        Blok[,] blokken;
        Hero thisHero;

        public bool xMovement = false;
        public bool onPlat = false;

        public Collision(Hero _hero, Blok[,] blokArray)
        {
            thisHero = _hero;
            blokken = blokArray;
        }

        #region CollisionCheck
        public void CheckCollision()
        {
            Console.WriteLine("word ik opgeroepen?");
            onPlat = false;
            //thisHero.BootsOnTheGround = false;
            foreach (Blok blok in blokken)
            {

                xMovement = false;
                if (blok != null)
                {
                    blok.OnPLatform = false;
                    //Check for collision from the left side of the hero (thus he is walking to the left)
                    if (thisHero.CollisionRectangle.Intersects(blok.CollisionRectangle) && thisHero.CollisionRectangle.Left + 15 < blok.CollisionRectangle.Right && thisHero.input.Left == true)
                    {
                        thisHero.Position.X += 2;
                        xMovement = true;
                    }
                    //Check for collision from the right side of the hero (thus he is walking to the right)
                    if (thisHero.CollisionRectangle.Intersects(blok.CollisionRectangle) && thisHero.CollisionRectangle.Right - 15 > blok.CollisionRectangle.Left && thisHero.input.Right == true)
                    {
                        thisHero.Position.X -= 2;
                        xMovement = true;
                    }
                    //Check for collision with hero and a blok underneath it
                    if (thisHero.CollisionRectangle.Bottom + 25 >= blok.CollisionRectangle.Top && thisHero.CollisionRectangle.Top < blok.CollisionRectangle.Top && ((thisHero.CollisionRectangle.Left + 15 >= blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Left + 15 <= blok.CollisionRectangle.Right) || (thisHero.CollisionRectangle.Right - 15 >= blok.CollisionRectangle.Left && thisHero.CollisionRectangle.Right - 15 <= blok.CollisionRectangle.Right)))
                    {
                        thisHero.Position.Y = blok.CollisionRectangle.Top - thisHero.CollisionRectangle.Height - 20;
                        blok.OnPLatform = true;
                    }
                    if (blok.CollisionRectangle.Intersects(thisHero.CollisionRectangle) && thisHero.CollisionRectangle.Top < blok.CollisionRectangle.Bottom && thisHero.input.Jump == true)
                    {
                        thisHero.Position.Y += 2;
                    }
                    if (!thisHero.CollisionRectangle.Intersects(blok.CollisionRectangle) && !(thisHero.CollisionRectangle.Bottom + 15 >= blok.CollisionRectangle.Top))
                    {
                        //blok.OnPLatform = false;
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
                    }
                }

            }
            if (!onPlat)
            {
                thisHero.HasJumped = true;
                thisHero.BootsOnTheGround = false;
                Console.WriteLine("onplat");
            }
        }
        #endregion
    }
}
