using _2D_Game.Animations;
using _2D_Game.MovingSprites.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites
{
    public abstract class Sprite: ISprite
    {
        #region Properties
        public Texture2D SpriteTexture { get; set; }
        public AnimationMotion SpriteAnimation { get; set; }

        public bool BootsOnTheGround { get; set; }

        public int Health { get; set; }
        public bool HasJumped { get; set; }

        protected Rectangle collisionRectangle;

        public Rectangle CollisionRectangle
        {
            get { return collisionRectangle; }
            set { collisionRectangle = value; }
        }
        #endregion

        #region Variables
        public Vector2 Position;
        public Vector2 Velocity;
        protected bool goingLeft;
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
            Velocity = new Vector2(3, 0);
            goingLeft = false;
        }

        public Sprite(Vector2 _position, Vector2 _velocity, bool _goingLeft)
        {
            //Variable declaration
            Position = _position;
            Velocity = _velocity;
            goingLeft = _goingLeft;
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
        public abstract void HasDied();
        public abstract void Relocate();
        #endregion
    }
}
