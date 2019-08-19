using _2D_Game.CoreClasses;
using _2D_Game.LevelDesign.Interfaces;
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
    class Level1: LevelFactoryWithEnemies, ILevelfactory_Enemies
    {
        #region Constructor
        /// <summary>
        /// Constructor for the class.
        /// Initializes and creates enemies, which type of tile is used where and starts the collision for both hero and enemies alike.
        /// </summary>
        /// <param name="_content"></param>
        /// <param name="myHero"></param>
        public Level1(ContentManager _content, Hero myHero) //: base(myHero)
        {
            enemies = new List<Enemies>();
            CreateEnemies(_content);
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
            heroCollisionChecker = new HeroCollisionWithEnemies(myHero, blokArray, enemies);
            enemyCollisionChecker = new EnemyCollision(blokArray, enemies);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the amount of enemies needed for this level with their specific texture and location spawning system.
        /// </summary>
        /// <param name="content"></param>
        public override void CreateEnemies(ContentManager content)
        {
            enemies = enemyCreator.GenerateEnemies(25, content.Load<Texture2D>("EnemyWalker"), new Vector2(0, -100), 12301);
            foreach (Enemies enemy in enemies)
            {
                enemy.Relocator = enemy.Position;
            }
        }
        #endregion  
    }
}
