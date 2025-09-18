namespace EF_AsyncCalculatr
{
    delegate int Calculate(int x, int y);
    class Program
    {
        public static int Sum(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
        public static int Multiply(int x, int y)
        {
            return x * y;
        }
        public static int Divide(int x, int y)
        {
            if (y == 0)
                return 0;
            return x / y;
        }

        public static async System.Threading.Tasks.Task<int> CalculateAsync(Calculate calc, int x, int y)
        {
            return await System.Threading.Tasks.Task.Run(() => calc(x, y));
        }

        public static void Main(string[] args)
        {
            Calculate calc = Sum;
            var task = CalculateAsync(calc, 10, 5);
            task.Wait();
            System.Console.WriteLine($"Result: {task.Result}");
        }
    }
}