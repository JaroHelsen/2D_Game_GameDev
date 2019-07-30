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
        public Boolean Left { get; set; }
        public Boolean Right { get; set; }
        public Boolean Jump { get; set; }
        public abstract void Update();
    }

    public class BedieningPijltjes: Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            //bool isIdle = true;
            Console.WriteLine("update input");
            if (stateKey.IsKeyDown(Keys.Left))
            {
                Left = true;
                //isIdle = false;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
                //isIdle = true;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                Right = true;
                //isIdle = false;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
                //isIdle = true;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                Jump = true;
                //isIdle = false;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
                //isIdle = true;
            }
            //if (Left == false && Right == false && Jump == false)
            //{
            //    isIdle = true;
            //}
            //else
            //{
            //    isIdle = false;
            //}
            //if (isIdle == true /*&& stateKey.GetPressedKeys() == null || stateKey.GetPressedKeys().Length == 0*/)
            //{
            //    Idle = true;
            //}
        }
    }
}
