using CsvHelper;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace BoxCorp.App 
{
    class Program 
    {
        static async Task Main(string[] args) 
        {
            var sw = new Stopwatch();
            sw.Start();

            var boxDecisioning = new BoxDecisioning();

            using (var reader = new StreamReader("boxes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.TypeConverterOptionsCache.GetOptions<decimal>().NumberStyle = NumberStyles.Number | NumberStyles.AllowExponent;
                await csv.ReadAsync();
                csv.ReadHeader();

                var id = 0;
                while (await csv.ReadAsync())
                {
                    id++;

                    var x = csv.GetField<int>("X");
                    var y = csv.GetField<int>("Y");
                    var width = csv.GetField<int>("Width");
                    var height = csv.GetField<int>("Height");
                    var rank = csv.GetField<decimal>("Rank");

                    var box = new Box(id, x, y, width, height, rank);
                    boxDecisioning.Push(id, box);
                }

                sw.Stop();
                Console.WriteLine($"Loading time: {sw.ElapsedMilliseconds} milliseconds");
                Console.WriteLine($"Total Boxes: {id}");

                sw.Reset();
            }

            sw.Start();
            
            boxDecisioning.Decisioning();
            Console.WriteLine($"Total Boxes after decisioning: {boxDecisioning.BoxCount}");

            sw.Stop();
            Console.WriteLine($"Total Milliseconds: {sw.ElapsedMilliseconds}");
        }
    }
}
