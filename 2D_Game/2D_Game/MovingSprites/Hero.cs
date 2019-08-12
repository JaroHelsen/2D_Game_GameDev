using _2D_Game.Animations;
using _2D_Game.Controls;
using _2D_Game.MovingSprites.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites
{
    public class Hero :  Sprite, IHero
    {
        #region Properties
        public AnimationMotion HeroAnimation { get; set; }
        
        #endregion

        #region Variables
        public BedieningPijltjes input;
        private Vector2 relocator;

        //Animations
        private AnimationMotion _runningRightAnimation;
        private AnimationMotion _runningLeftAnimation;
        private AnimationMotion _jumpingAnimation;
        private Texture2D runningRightTexture;
        private Texture2D runningLeftTexture;
        private Texture2D jumpingTexture;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates and initalizes the hero.
        /// Sprite textures are loaded in so we can have different animations and textures.
        /// Animations are loaded in and given a AantalBewegingenPerSeconde.
        /// The collisionrectangle is created using the position of the sprite and the texture.
        /// Health has been set so that the player can die when it hits an enemy or jumps in the water.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="_position"></param>
        public Hero(ContentManager content, Vector2 _position) : base(_position)
        {
            relocator = _position;
            //Textures loaden
            SpriteTexture = content.Load<Texture2D>("Herosprites/Walking_right");
            runningRightTexture = content.Load<Texture2D>("HeroSprites/Walking_right");
            runningLeftTexture = content.Load<Texture2D>("HeroSprites/Walking_left");
            jumpingTexture = content.Load<Texture2D>("HeroSprites/Jumping");

            //Animations loaden
            HeroAnimation = new AnimationMotion();
            HeroAnimation.AddAnimation(SpriteTexture, 4);
            HeroAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 2;

            _runningRightAnimation = new AnimationMotion();
            _runningRightAnimation.AddAnimation(runningRightTexture, 4);
            _runningRightAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 2;
            _runningLeftAnimation = new AnimationMotion();
            _runningLeftAnimation.AddAnimation(runningLeftTexture, 4);
            _runningLeftAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 2;
            _jumpingAnimation = new AnimationMotion();
            _jumpingAnimation.AddAnimation(jumpingTexture, 1);
            _jumpingAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 1;

            //CollisionRectangle loaden
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, SpriteTexture.Width, SpriteTexture.Height / 4);

            //Make Hero fall to its position
            HasJumped = true;

            //Set Health for 100
            Health = 100;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the hero position using the input variable which uses the arrow keys for movement.
        /// Checks in which direction the user wants the hero to move and then edits the position accordingly.
        /// Also checks if the player is going right or left, so that the jumping animation can be flipped accordingly in the Draw method.
        /// Edits the collisionrectangle so that it is always in the right position.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Console.WriteLine(Position);
            Console.WriteLine("Hallo");
            input.Update();
            Position.Y += Velocity.Y;
            if (input.Left || input.Right || input.Jump)
            {
                HeroAnimation.Update(gameTime);
            }
            if (input.Right || input.Left)
            {
                if (input.Right)
                {
                    Position.X += Velocity.X;
                    goingLeft = false;
                }
                else if (input.Left)
                {
                    Position.X -= Velocity.X;
                    goingLeft = true;
                }
                if (HasJumped == false)
                {
                    SpriteTexture = runningRightTexture;

                    HeroAnimation = _runningRightAnimation;
                    _runningRightAnimation.Update(gameTime);
                }

            }
            if (input.Jump && HasJumped == false)
            {
                Console.WriteLine("jump");
                Position.Y -= 40f;
                Velocity.Y = -7f;
                HasJumped = true;
                BootsOnTheGround = false;
                SpriteTexture = jumpingTexture;
                HeroAnimation = _jumpingAnimation;
                _jumpingAnimation.Update(gameTime);

            }
            if (HasJumped)
            {
                Console.WriteLine("hasjump");
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
        /// Draws the hero using the spriteBatch.Draw method.
        /// Flips the image if the hero is going left.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(HeroTexture, CollisionRectangle, Color.AliceBlue);
            spriteBatch.Draw(SpriteTexture, new Vector2((int)Position.X, (int)Position.Y + 27), HeroAnimation.CurrentAnimation.CurrentFrame.SourceRectangle, Color.AliceBlue, 0f, Vector2.Zero, 1f, goingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }

        /// <summary>
        /// Resets the health and then relocates to the last starting position.
        /// </summary>
        public void HasDied()
        {
            Health = 100;
            Position = relocator;
            goingLeft = false;
            SpriteTexture = runningRightTexture;
        }
        #endregion
    }
}
