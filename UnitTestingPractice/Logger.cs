
using System;

namespace UnitTestingPractice
{

    public class Logger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

   
}
