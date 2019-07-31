using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.CoreClasses
{
    class Camera
    {
        public Matrix Transform { get; private set; }

        #region Methods
        /// <summary>
        /// Lets the camera follow the target around the screen.
        /// Target will always be in the centre of the screen.
        /// </summary>
        /// <param name="target"></param>
        public void Follow(Vector2 target)
        {
            var position = Matrix.CreateTranslation(
                -target.X,
                -target.Y,
                0);

            var offset = Matrix.CreateTranslation(
                Game1.screenWidth / 2,
                Game1.screenHeight / 2,
                0);

            Transform = position * offset;
        }
        #endregion
    }
}
