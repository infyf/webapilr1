using System;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static async Task Main()
    {

        // 1. Робота з колекціями (System.Linq)
        int[] numb = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var ev = numb.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"Парні числа: {string.Join(", ", ev)}");


        // 2. Робота з файлами (System.IO)
        string fi = "data.txt";
        await File.WriteAllTextAsync(fi, "Hello, .NET Standard!");
        Console.WriteLine("Файл створено і записано.");

        // 3. Серіалізація JSON (System.Text.Json)
        var person = new { Name = "Maks", Age = 20 };
        string json = JsonSerializer.Serialize(person);
        await File.WriteAllTextAsync("person.json", json);
        Console.WriteLine("JSON збережено.");


        // 4. Використання таймера (System.Diagnostics)
        Stopwatch st = Stopwatch.StartNew();
        await Task.Delay(1000); 
        st.Stop();
        Console.WriteLine($"Час виконання: {st.ElapsedMilliseconds} мс");

        // 5. Асинхронна обробка (System.Threading.Tasks)
        await Prk();

        // 6. Робота з HTTP запитами (System.Net)
        using (var client = new WebClient())
        {
            string url = "https://jsonplaceholder.typicode.com/todos/4";
            string response = await client.DownloadStringTaskAsync(url);
            Console.WriteLine($"Отримано дані: {response}");
        }

        // 7. Використання списку (System.Collections.Generic)
        List<string> obj = new List<string> { "Car", "YouTube", "far " };
        obj.Add("csv");
        Console.WriteLine("Object: " + string.Join(", ", obj));

     
    }

    static async Task Prk()
    {
        Console.WriteLine("Запуск асинхронного процесу...");
        await Task.Delay(2000);
        Console.WriteLine("Асинхронний процес завершено.");
    }
}
