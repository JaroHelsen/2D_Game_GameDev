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
        public bool isVisible = false;
        Random random = new Random();
        int randX;
        private Vector2 startPosition;


        /// <summary>
        /// Constructor for the Enemies
        /// </summary>
        /// <param name="_position"></param>
        /// <param name="_texture"></param>
        public Enemies(Vector2 _position, Texture2D _texture) : base(_position)
        {
            SpriteTexture = _texture;
            startPosition = _position;
            randX = random.Next(-4, -1);
            Velocity = new Vector2(randX, 0);
        }

        /// <summary>
        /// Updating the movement so the enemy can move left and right for a set amount of paces.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            //if (Position.Y <=0 || Position.Y >= Game1.screenHeight -  SpriteTexture.Height)
            //{
            //    Velocity.Y = -Velocity.Y;
            //}
            if (Position.X > startPosition.X + 20)
            {
                Position.X = -Position.X;
            }
            else if (Position.X < startPosition.X + 20)
            {
                Position.X = -Position.X;
            }
        }

        /// <summary>
        /// Drawing the enemy.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SpriteTexture, Position, Color.AliceBlue);
        }
    }
}
