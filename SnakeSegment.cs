using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRender;

namespace Snake
{
    internal class SnakeSegment : AbstractSnakeSegment
    {
        AbstractSnakeSegment next;
        public SnakeSegment(int X, int Y, Render render, AbstractSnakeSegment NextSegment) : base(X, Y, render)
        {
            next = NextSegment;
        }
        public override void Update()
        {
            X = next.X;
            Y = next.Y;
            render.SetSymbol(X, Y, '+');
            next.Update();
        }
    }
}
