using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Main
{
    public static class AsyncExample
    {
        public static void Run()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Showing that tasks are executed parallel and not one after another");

            var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var tasks1 = new List<Task<int>>();

            foreach(var x in values)
            {
                var task = Task.Run(() =>
                {
                    //make some long calculation
                    Console.WriteLine($"Task 1 Value {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0)).Wait();
                    return x;
                });
                tasks1.Add(task);
            }
            
            var tasks2 = new List<Task<int>>();
            foreach(var task in tasks1)
            {
                tasks2.Add(
                    task.ContinueWith(t => { Console.WriteLine($"\tTask 2 Value { t.Result}"); return t.Result; })
                );
            }
            var task3 = Task3(tasks2);

            task3.Wait();
        }

        public static async Task Task3(List<Task<int>> tasks)
        {
            foreach (var task in tasks)
            {
                var futuredata = await task.ContinueWith(t => { Console.WriteLine($"\t\tTask 3 Value { t.Result}"); return t.Result; });
            }
        }
    }
}
