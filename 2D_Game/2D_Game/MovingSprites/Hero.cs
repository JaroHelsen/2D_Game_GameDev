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
        public BedieningPijltjes input;


        public bool HasJumped { get; set; }
        private Rectangle collisionRectangle;

        public Rectangle CollisionRectangle
        {
            get { return collisionRectangle; }
            set { collisionRectangle = value; }
        }
        public AnimationMotion HeroAnimation { get; set; }

        #region Variabelen
        private AnimationMotion runningRightAnimation;
        private AnimationMotion runningLeftAnimation;
        private AnimationMotion jumpingAnimation;
        private Texture2D runningRightTexture;
        private Texture2D runningLeftTexture;
        private Texture2D jumpingTexture;
        #endregion

        public Hero(ContentManager content, Vector2 _position) : base(_position)
        {
            //Textures loaden
            SpriteTexture = content.Load<Texture2D>("Herosprites/Walking_right");
            runningRightTexture = content.Load<Texture2D>("HeroSprites/Walking_right");
            runningLeftTexture = content.Load<Texture2D>("HeroSprites/Walking_left");
            jumpingTexture = content.Load<Texture2D>("HeroSprites/Jumping");

            //Animations loaden
            HeroAnimation = new AnimationMotion();
            HeroAnimation.AddAnimation(SpriteTexture, 4);
            HeroAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 5;

            runningRightAnimation = new AnimationMotion();
            runningRightAnimation.AddAnimation(runningRightTexture, 4);
            runningRightAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 5;
            runningLeftAnimation = new AnimationMotion();
            runningLeftAnimation.AddAnimation(runningLeftTexture, 4);
            runningLeftAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 5;
            jumpingAnimation = new AnimationMotion();
            jumpingAnimation.AddAnimation(jumpingTexture, 1);
            jumpingAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 1;

            //CollisionRectangle loaden
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, SpriteTexture.Width, SpriteTexture.Height / 4);

            //Make Hero fall to its position
            HasJumped = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, new Vector2((int)Position.X, (int)Position.Y + 27), HeroAnimation.CurrentAnimation.CurrentFrame.SourceRectangle, Color.AliceBlue, 0f, Vector2.Zero, 1f, goingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }

        public void HasDied()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            input.Update();
            Position += Velocity;
            if (input.Left || input.Right || input.Jump)
            {
                HeroAnimation.Update(gameTime);
            }
            if (input.Right || input.Left)
            {
                if (input.Right)
                {
                    Position.X += XVelocity.X;
                    goingLeft = false;
                }
                else if (input.Left)
                {
                    Position.X -= XVelocity.X;
                    goingLeft = true;
                }
                if (HasJumped == false)
                {
                    SpriteTexture = runningRightTexture;

                    HeroAnimation = runningRightAnimation;
                    runningRightAnimation.Update(gameTime);
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
                HeroAnimation = jumpingAnimation;
                jumpingAnimation.Update(gameTime);

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
    }
}
