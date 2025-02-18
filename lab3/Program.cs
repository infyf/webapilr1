using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Main started");

   
        Thread thread1 = new Thread(FirstThreadMethod);
        Thread thread2 = new Thread(SecondThreadMethod);
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();

        // Виклик асинхронних методів
        Task task1 = Asy();
        Task task2 = AnA();
        Task task3 = Asyn();
        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine("Main finished");
    }


    static void FirstThreadMethod()
    {
        Console.WriteLine("Thread 1 started");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Thread 1: Processing item {i}/5");
            Thread.Sleep(500); 
        }
        Console.WriteLine("Thread 1 completed");
    }

    static void SecondThreadMethod()
    {
        Console.WriteLine("Thread 2 started");
        for (int i = 10; i <= 13; i++)
        {
            Console.WriteLine($"Thread 2: Processing task {i}/13");
            Thread.Sleep(800); 
        }
        Console.WriteLine("Thread 2 completed");
    }


  
    static async Task Asy()
    {
        Console.WriteLine("Downloading file...");
        await Task.Delay(2000); 
        Console.WriteLine("File downloaded and ready for use!");
    }

    static async Task AnA()
    {
        Console.WriteLine("Starting computation...");
        await Task.Run(async () =>
        {
            int result = 0;
            for (int i = 1; i <= 3; i++)
            {
                result += i * 10;
                Console.WriteLine($"Computed partial sum: {result}");
                await Task.Delay(800); 
            }
        });
        Console.WriteLine("Computation completed!");
    }

    static async Task Asyn()
    {
        Console.WriteLine("Checking server connection...");
        await Task.Delay(1500); 
        Console.WriteLine("Server is online!");
    }
}
