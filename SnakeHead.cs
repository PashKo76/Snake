using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRender;

namespace Snake
{
    internal class SnakeHead : AbstractSnakeSegment
    {
        List<SnakeSegment> segments;
        ConsoleKey key = ConsoleKey.RightArrow;
        Fruit fruit;
        Message message;
        public SnakeHead(int X, int Y, Render render, List<SnakeSegment> segments, Fruit fruit, Message message) : base(X, Y, render)
        {
            render.SetSymbol(X, Y, '@');
            this.segments = segments;
            this.fruit = fruit;
            this.message = message;
        }
        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey().Key;
            }
            ChangePos();
            if (CheckCollision())
            {
                message.Invoke();
            }
            render.SetSymbol(X, Y, '@');
        }
        bool CheckCollision()
        {
            if (CheckCordinateCollision(fruit.X, fruit.Y))
            {
                fruit.ChangePos();
                segments.Add(new SnakeSegment(-1, -1, render, segments.Last()));
            }
            foreach (SnakeSegment item in segments)
            {
                if (CheckCordinateCollision(item.X, item.Y)) return true;
            }
            return CheckBarierCollision();
        }
        bool CheckBarierCollision()
        {
            if (0 > X || X >= Render.width || 0 > Y || Y >= Render.height) return true;
            return false;
        }
        bool CheckCordinateCollision(int X, int Y)
        {
            if (this.X == X && this.Y == Y) return true;
            return false;
        }
        void ChangePos()
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    X += 1;
                    break;
                case ConsoleKey.DownArrow:
                    Y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    X -= 1;
                    break;
                case ConsoleKey.UpArrow:
                    Y -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}
