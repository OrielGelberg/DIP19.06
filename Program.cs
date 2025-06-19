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
    // Example 1: Dependency Inversion Principle (DIP) in C#
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

    // Exaple 2
    public interface ILieDetector
    {
        bool DetectLie(string answer);
    }

    public class VoiceAnalyzer : ILieDetector
    {
        public bool DetectLie(string answer)
        {
            return answer.Contains("uh");
        }
    }

    public class ThermalScanner : ILieDetector
    {
        public bool DetectLie(string answer)
        {
            return false;
        }
    }

    public class TerroristInterrogationUnit
    {
        private readonly ILieDetector detector;

        public TerroristInterrogationUnit(ILieDetector detector)
        {
            this.detector = detector;
        }

        public void Interrogate(string answer)
        {
            if (detector.DetectLie(answer))
                Console.WriteLine("Lie detected!");
            else
                Console.WriteLine("Truth detected.");
        }
    }
    // Example 3: Dependency Inversion Principle (DIP) in C#
    public interface IAlert
    {
        void Alert();
    }

    public class SirenAlert : IAlert
    {
        public void Alert()
        {
            Console.WriteLine("Siren activated!");
        }
    }

    public class DroneDispatchAlert : IAlert
    {
        public void Alert()
        {
            Console.WriteLine("Drone dispatched!");
        }
    }

    public class BaseDefenseController
    {
        private readonly IAlert alert;

        public BaseDefenseController(IAlert alert)
        {
            this.alert = alert;
        }

        public void HandleThreat()
        {
            alert.Alert();
        }
    }
}
