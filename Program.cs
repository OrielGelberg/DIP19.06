using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP19._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[FILE] {message}");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[CONSOLE] {message}");
        }
    }

    public class MissionController
    {
        private readonly ILogger logger;

        public MissionController(ILogger logger)
        {
            this.logger = logger;
        }

        public void RunMission()
        {
            Console.WriteLine("Running mission...");
            logger.Log("Mission completed.");
        }
    }
}
