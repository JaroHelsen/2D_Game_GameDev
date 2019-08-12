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
    class Enemies: Sprite
    {
        public AnimationMotion HeroAnimation { get; set; }
        Vector2 origin;
        float rotation = 0f;

        bool right;
        float distance, oldDistance;
        public Enemies(Texture2D _texture, Vector2 _position, float _distance):base(_position)
        {
            SpriteTexture = _texture;
            //position = _position;
            distance = _distance;

            oldDistance = distance;

            Health = 10;
            HasJumped = true;

            //Animations loaden
            HeroAnimation = new AnimationMotion();
            HeroAnimation.AddAnimation(SpriteTexture, 4);
            HeroAnimation.CurrentAnimation.AantalBewegingenPerSeconde = 2;


            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, SpriteTexture.Width, SpriteTexture.Height / 4);
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            origin = new Vector2(SpriteTexture.Width / 2, SpriteTexture.Height / 2);
            HeroAnimation.Update(gameTime);

            if (distance <= 0)
            {
                right = true;
                Velocity.X = 1f;
            }
            else if(distance >= oldDistance)
            {
                right = false;
                Velocity.X = -1f;
            }

            if (right)
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
            if (Velocity.X > 0)
            {
                spriteBatch.Draw(SpriteTexture, Position, null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(SpriteTexture, Position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
