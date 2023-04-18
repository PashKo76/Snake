using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRender;

namespace Snake
{
    internal class Fruit : AbstractSnakeSegment
    {
        Random random = new Random();
        public Fruit(int X, int Y, Render render) : base(X, Y, render) { }
        public override void Update()
        {
            render.SetSymbol(X, Y, 'F');
        }
        public void ChangePos()
        {
            X = random.Next(0, Render.width - 1);
            Y = random.Next(0, Render.height - 1);
        }
    }
}
