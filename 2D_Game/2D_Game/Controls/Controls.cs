using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game.Controls
{
    public abstract class Controls
    {
        /// <summary>
        /// Abstract class so we can use other input methods eventually.
        /// </summary>
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Jump { get; set; }
        public abstract void Update();
    }

    public class BedieningPijltjes : Controls
    {
        /// <summary>
        /// Updates the input.
        /// Checks the key state and sets a boolean to true/false/nothing depending on if the if was true or not.
        /// You cannot push the left and the right button at once.
        /// </summary>
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            Console.WriteLine("update input");
            if (stateKey.IsKeyDown(Keys.Left) && Right == false)
            {
                Left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
            }

            if (stateKey.IsKeyDown(Keys.Right) && Left == false)
            {
                Right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
        }
    }
}
