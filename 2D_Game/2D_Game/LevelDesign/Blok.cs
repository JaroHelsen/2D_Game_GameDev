using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.LevelDesign
{
    class Blok
    {
        #region Properties
        public bool onCheck = true;
        public Vector2 Position { get; set; }
        public bool OnPLatform { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle collisionRectangle;

        public Rectangle CollisionRectangle
        {
            get { return collisionRectangle; }
            set { collisionRectangle = value; }
        }
        public int Id { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a Blok object and asks for a texture and the position of the Blok obect.
        /// It then creates a collisionrectangle for the object using its position and texture.
        /// Sets the OnPlatform to false. This is because when everything is first drawn up the hero does not touch a Blok object.
        /// </summary>
        /// <param name="_texture"></param>
        /// <param name="_position"></param>
        public Blok(Texture2D _texture, Vector2 _position)
        {
            Position = _position;
            Texture = _texture;
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            OnPLatform = false;
        }
        #endregion

        #region Method: Draw
        /// <summary>
        /// Draws the Blok object.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }
        #endregion
    }
}
