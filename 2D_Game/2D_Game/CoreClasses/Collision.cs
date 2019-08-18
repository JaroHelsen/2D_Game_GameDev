using _2D_Game.LevelDesign;
using _2D_Game.MovingSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.Main
{
    public abstract class Collision
    {
        #region Variables
        protected Blok[,] blokken;
        protected Hero thisHero;
        protected List<Enemies> enemies;

        public bool xMovement = false;
        public bool onPlat = false;
        public bool Auwch = false;

        private Game1 game;
        #endregion

        #region Constructor
        public Collision(Hero _hero, Blok[,] blokArray, List<Enemies> _enemy)
        {
            thisHero = _hero;
            game = new Game1();
            blokken = blokArray;
            enemies = _enemy;
        }

        public Collision(Blok[,] blokArray, List<Enemies> _enemy)
        {
            thisHero = null;
            game = new Game1();
            blokken = blokArray;
            enemies = _enemy;
        }
        public Collision(Hero _hero, Blok[,] blokArray)
        {
            thisHero = _hero;
            blokken = blokArray;
            game = new Game1();
            enemies = null;
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
        public abstract void CheckCollision();
        #endregion
    }
}
