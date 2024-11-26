using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void ThreadExample()
    {
        Thread thread = new Thread(() =>
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Thread: виконання {i}");
                Thread.Sleep(1000); 
            }
        });

        thread.Start();
        thread.Join(); 
        Console.WriteLine("Thread завершив виконання.\n");
    }

    static async Task AsyncExample()
    {
        Console.WriteLine("Async: початок виконання.");
        await Task.Delay(5000); 
        Console.WriteLine("Async: виконання завершено.\n");
    }

    static async Task AnotherAsyncExample()
    {
        Console.WriteLine("AnotherAsync: виконання запущено.");
        await Task.Run(() =>
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"AnotherAsync: обробка {i}");
                Thread.Sleep(700);
            }
        });
        Console.WriteLine("AnotherAsync: виконання завершено.\n");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Демонстрація роботи Thread:");
        ThreadExample();

        Console.WriteLine("Демонстрація роботи Async/Await:");
        Task asyncTask = AsyncExample();
        Task anotherAsyncTask = AnotherAsyncExample();

        Task.WaitAll(asyncTask, anotherAsyncTask);

        Console.WriteLine("Виконання завершено.");
    }
}
