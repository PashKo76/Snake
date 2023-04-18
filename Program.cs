using ConsoleRender;
namespace Snake
{
    delegate void Message();
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsGameAlive = true;
            int SleepTime;
            Render.Initialize(90, 30);
            Render render = new Render();
            List<SnakeSegment> segments = new List<SnakeSegment>();
            Fruit fruit = new Fruit(10, 10, render);
            SnakeHead head = new SnakeHead(Render.width/2, Render.height / 2, render, segments, fruit, () => IsGameAlive = false);
            segments.Add(new SnakeSegment(-1, -1, render, head));
            for(int i = 0; i < 2; i++)
            {
                segments.Add(new SnakeSegment(-1, -1, render, segments[i]));
            }
            render.SmartRender();
            long PlayTime = Render.CalculateRunTime(() =>
            {
                while (IsGameAlive)
                {
                    SleepTime = 250;
                    SleepTime -= (int)Render.CalculateRunTime(() =>
                    {
                        segments.Last().Update();
                        fruit.Update();
                        render.SmartRender();
                    });
                    if (SleepTime > 0)
                    {
                        Thread.Sleep(SleepTime);
                    }
                }
            });
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"You played {PlayTime} milliseconds");
            Console.WriteLine("Please press Enter");
            Console.ReadKey();
        }
    }
}