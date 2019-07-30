﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites
{
    public abstract class Sprite
    {
        #region Properties
        public Texture2D SpriteTexture { get; set; }

        public bool BootsOnTheGround { get; set; }

        public int Health { get; set; }
        #endregion

        #region Variables
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 XVelocity;
        public bool goingLeft;
        #endregion

        #region Constructor
        /// <summary>
        /// The constructor of the class.
        /// The hero and enemies get a default value for goingLeft and their movementspeed on Xvelocity.
        /// Position is also initialized as to spawn the player and enemies at the right position.
        /// </summary>
        /// <param name="_position"></param>
        public Sprite(Vector2 _position)
        {
            //Variable declaration
            Position = _position;
            XVelocity = new Vector2(3, 0);
            goingLeft = false;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update and Draw methods for the hero and the enemies. 
        /// Are declared abstract because they are unique to the subclass.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        #endregion
    }
}
