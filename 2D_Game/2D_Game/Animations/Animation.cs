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
        List<AnimationFrame> frames;
        public Texture2D Texture { get; set; }
        public Double Offset { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public int AantalBewegingenPerSeconde { get; set; }

        private int counter;
        private double x = .0;
        private int totalHeight = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            AantalBewegingenPerSeconde = 1; //TODO: veranderen naar een doorgegeven var afhankelijk van level of dergelijke
        }

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
                totalHeight += f.SourceRectangle.Height;
            }
        }

        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Height * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if (x >= CurrentFrame.SourceRectangle.Height / AantalBewegingenPerSeconde)
            {
                Console.WriteLine(x);
                x = 0;
                counter++;
                if (counter >= frames.Count)
                {
                    counter = 0;
                }
                CurrentFrame = frames[counter];
                Offset += CurrentFrame.SourceRectangle.Height;
            }
            if (Offset >= totalHeight)
            {
                Offset = 0;
            }
        }
    }
}
