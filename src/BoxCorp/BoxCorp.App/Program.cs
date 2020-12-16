using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
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
                while (await csv.ReadAsync())
                {
                    var x = csv.GetField<int>("X");
                    var y = csv.GetField<int>("Y");
                    var width = csv.GetField<int>("Width");
                    var height = csv.GetField<int>("Height");
                    var rank = csv.GetField<decimal>("Rank");

                    var box = new Box(x, y, width, height, rank);
                    boxDecisioning.Push(box);
                }

                sw.Stop();
                Console.WriteLine($"Loading time: {sw.ElapsedMilliseconds} Milliseconds");
                Console.WriteLine($"Total Boxes: {boxDecisioning.BoxCount}");

                sw.Reset();
            }

            sw.Start();

            boxDecisioning.RemoveLowRankBoxes();
            Console.WriteLine($"Total Boxes afer removing low rank ones: {boxDecisioning.BoxCount}");

            
            boxDecisioning.Decisioning();
            Console.WriteLine($"Total Boxes after decisioning: {boxDecisioning.BoxCount}");
            //boxDecisioning.Print();

            sw.Stop();
            Console.WriteLine($"Total Milliseconds: {sw.ElapsedMilliseconds}");
            

            Console.ReadKey();
        }
    }

    


    
}
