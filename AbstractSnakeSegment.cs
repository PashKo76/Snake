using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRender;

namespace Snake
{
    internal abstract class AbstractSnakeSegment
    {
        private protected Render render;
        public int X { get; private protected set; }
        public int Y { get; private protected set; }
        public AbstractSnakeSegment(int X, int Y, Render render)
        {
            this.X = X;
            this.Y = Y;
            this.render = render;
        }
        public abstract void Update();
    }
}
