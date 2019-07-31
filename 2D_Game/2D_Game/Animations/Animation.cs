using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.Animations
{
    public class Animation
    {
        #region Properties
        public Texture2D Texture { get; set; }
        public double Offset { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public int AantalBewegingenPerSeconde { get; set; }
        #endregion

        #region Variables
        private List<AnimationFrame> frames;
        private int counter;
        private double x = .0;
        private int _totalHeight = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// The constructor for the class.
        /// Creates a new list of AnimationFrame and puts it in the frames variable.
        /// </summary>
        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a frame to the frames list.  
        /// Gets the rectangle for the frame through a parameter when the method is called.
        /// Edits the totalheight of the frame so that it is known how large it is.
        /// This will come in handy when we want to cycle through the frames when we're updating.
        /// </summary>
        /// <param name="rectangle"></param>
        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame newFrame = new AnimationFrame()
            {
                SourceRectangle = rectangle,
            };
            frames.Add(newFrame);
            CurrentFrame = frames[0];
            Offset = CurrentFrame.SourceRectangle.Height;
            foreach (AnimationFrame f in frames)
            {
                _totalHeight += f.SourceRectangle.Height;
            }
        }

        /// <summary>
        /// Updates what the user sees.
        /// Makes it so that when the update method is called the frames list will be gone through from the front to the end and repeated untill the method is not being called anymore.
        /// Offset is used to check if we've exceeded the height of the texture.
        /// The counter tells us on which frame we are and checks if we've not exceeded the amount of frames, otherwise it will reset.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Height * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if (x >= CurrentFrame.SourceRectangle.Height / AantalBewegingenPerSeconde)
            {
                x = 0;
                counter++;
                if (counter >= frames.Count)
                {
                    counter = 0;
                }
                CurrentFrame = frames[counter];
                Offset += CurrentFrame.SourceRectangle.Height;
            }
            if (Offset >= _totalHeight)
            {
                Offset = 0;
            }
        }
        #endregion
    }
}
