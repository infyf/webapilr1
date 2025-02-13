using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Main started");

        Thr();
        Asy().Wait();
        AnA().Wait();

        Console.WriteLine("Main finished");
    }

    static void Thr()
    {
        Thread thread = new Thread(() =>
        {
            Console.WriteLine("Loading data...");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Processing batch {i + 1}/5");
                Thread.Sleep(600);
            }
            Console.WriteLine("Data loaded successfully!");
        });

        thread.Start();
        thread.Join();
    }

    static async Task Asy()
    {
        Console.WriteLine("Downloading file...");
        await Task.Delay(2500);
        Console.WriteLine("File downloaded and ready for use!");
    }

    static async Task AnA()
    {
        Console.WriteLine("Starting computation...");
        await Task.Run(() =>
        {
            int result = 0;
            for (int i = 1; i <= 3; i++)
            {
                result += i * 10;
                Console.WriteLine($"Computed partial sum: {result}");
                Thread.Sleep(800);
            }
        });
        Console.WriteLine("Computation completed!");
    }
}
