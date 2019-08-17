using _2D_Game.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.MovingSprites
{
    public class Enemies: Sprite
    {
        public AnimationMotion SpriteAnimation { get; set; }
        Vector2 origin;
        float rotation = 0f;
        float distance, oldDistance;
        public Enemies(Texture2D _texture, Vector2 _position, float _distance):base(_position)
        {
            SpriteTexture = _texture;
            //position = _position;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, new Vector2((int)Position.X - 47, (int)Position.Y - 32), SpriteAnimation.CurrentAnimation.CurrentFrame.SourceRectangle, Color.AliceBlue, 0f, Vector2.Zero, 2.5f, goingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }

        public override void HasDied()
        {
            Health = 0;
        }

        public override void Relocate()
        {
            Position = relocator;
            goingLeft = false;
        }
    }
}
