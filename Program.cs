using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace AnalysisText
{
    class Program
    {
        static List<string> SplitString(string str)
        {
            List<string> list = new List<string>();
            int i = 0;
            char[] stringArray = str.ToCharArray();
            while (i < str.Length - 2)
            {
                while(stringArray[i].ToString() == " " || stringArray[i+1].ToString() == " " || stringArray[i+2].ToString() == " ")
                    i += 1;
                list.Add(str.Substring(i, 3));
                i += 1;
            }
            return list;
        }
        static void Main(string[] args)
        {

            var startTime = System.Diagnostics.Stopwatch.StartNew();

            string str = "Вперед";
            List<string> list = SplitString(str);

            var result = list
                .GroupBy(item => item)
                .Select(item => new {
                    Name = item.Key,
                    Count = item.Count()
                })
                .OrderByDescending(item => item.Count)
                .ThenBy(item => item.Name);
            string report = String.Join(Environment.NewLine, result
              .Select(item => String.Format("{0} встречается столько раз {1}", item.Name, item.Count)));
            string[] FinalReport = report.Split("\n");
           
            startTime.Stop();
            var resultTime = startTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
            for(int i=0; i<10 && i < FinalReport.Length; i++)
                Console.WriteLine(string.Join("\n", FinalReport[i]));
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("Потрачено времени на выполнение: " + elapsedTime);
        }
    }
}
