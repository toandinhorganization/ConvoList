using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvoList.Helpers
{
    public static class DebugLogHelper
    {
        public static void LogDebugText(string className, string functionName, string text)
        {
#if DEBUG
            // Logs debug messages with class, function, and text details
            Console.WriteLine($"[{className}::{functionName}] {text}");
#endif
        }
    }
}
