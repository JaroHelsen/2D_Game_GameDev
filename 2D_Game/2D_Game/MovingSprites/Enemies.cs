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
    public class Enemies: Sprite, IEnemies
    {
        #region Properties
        public Vector2 Relocator { get; set; }
        #endregion

        #region Variables
        protected Vector2 origin;
        protected float distance, oldDistance;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the Enemies class. 
        /// </summary>
        /// <param name="_texture"></param>
        /// <param name="_position"></param>
        /// <param name="_distance"></param>
        public Enemies(Texture2D _texture, Vector2 _position, float _distance):base(_position)
        {
            SpriteTexture = _texture;
            distance = 300;

            oldDistance = distance;

            Health = 10;
            HasJumped = true;

            //Animations loaden
            SpriteAnimation = new AnimationMotion();
            SpriteAnimation.AddAnimation(SpriteTexture, 4);
            SpriteAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 2;


            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, SpriteTexture.Width, SpriteTexture.Height / 4);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update method so the enemy is seen to be moving and the variable that allows the change of sprite orientation depending on which side it is walking towards is updated.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            origin = new Vector2(SpriteTexture.Width / 2, SpriteTexture.Height / 2);
            SpriteAnimation.Update(gameTime);

            if (distance <= 0)
            {
                goingLeft = false;
                Velocity.X = 1f;
            }
            else if(distance >= oldDistance)
            {
                goingLeft = true;
                Velocity.X = -1f;
            }

            if (!goingLeft)
            {
                distance += 1;
            }
            else
            {
                distance -= 1;
            }
            if (HasJumped)
            {
                Console.WriteLine("hasjumpeded");
                float i = 1;
                Velocity.Y += 0.15f * i;
            }
            if (BootsOnTheGround)
            {
                Console.WriteLine("boots");
                HasJumped = false;
                Velocity.Y = 0f;
            }

            collisionRectangle.X = (int)Position.X;
            collisionRectangle.Y = (int)Position.Y;
        }

        /// <summary>
        /// Draws the enemy.
        /// Edits to the position were made so that the enemy doesn't float above the ground
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, new Vector2((int)Position.X - 47, (int)Position.Y - 32), SpriteAnimation.CurrentAnimation.CurrentFrame.SourceRectangle, Color.AliceBlue, 0f, Vector2.Zero, 2.5f, goingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }

        /// <summary>
        /// Method that gets called when the enemy dies.
        /// </summary>
        public override void HasDied()
        {
            Health = 0;
        }

        /// <summary>
        /// Method that gets called when the enemy has to respawn after the restart of a level. It also resets it's orientation and health.
        /// </summary>
        public override void Relocate()
        {
            Position = Relocator;
            Health = 10;
            goingLeft = true;
            HasJumped = true;
        }
        #endregion
    }
}
