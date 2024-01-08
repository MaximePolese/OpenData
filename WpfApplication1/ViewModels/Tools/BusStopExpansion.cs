using System.Collections.Generic;
using ClassLibrary1;

namespace WpfApplication1.ViewModels.Tools
{
    public static class BusStopExpansion
    {
        public static List<string> GetConnectionLines(this BusStop busStop)
        {
            return new List<string>(busStop.lines);
        }

        public static string GetConnectionLinesString(this BusStop busStop)
        {
            string lines = "";
            foreach (var connectionLine in busStop.GetConnectionLines())
            {
                lines += connectionLine;
                lines += " ";
            }

            return lines;
        }

        public static Dictionary<string, string> GetConnectionsLinesOrderedByDoer(this BusStop busStop)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var connectionLine in busStop.GetConnectionLines())
            {
                var line = connectionLine.Split(':');
                result.Add(line[1], line[0]);
            }
            return result;
        }
    }
}