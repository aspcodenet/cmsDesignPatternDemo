using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    interface ILogger
    {
        void LogError(string txt);
        void LogWarning(string txt);
    }
    class FileLogger : ILogger
    {
        public void DeleteOldFiles()
        {

        }
        public void LogError(string txt)
        {
            System.IO.File.AppendAllText("log.txt", txt);
        }

        public void LogWarning(string txt)
        {
            System.IO.File.AppendAllText("log.txt", txt);
        }
    }
    class ConsoleLogger : ILogger
    {
        public void LogError(string txt)
        {
            Console.WriteLine($"Error---{txt}");
            //Send email to admin
        }

        public void LogWarning(string txt)
        {
            Console.WriteLine($"Warning---{txt}");
        }
    }

    class Player
    {
        public Player(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }
    
    class Program
    {
        static Player GetOldest(ICollection<Player> players)
        {
            return players.First();
        }
        static void Main(string[] args)
        {
            var playerList = new List<Player>
            {
                new Player("Sudden", 49),
                new Player("Foppa", 47),
                new Player("Zäta", 40)
            };
            Player p = GetOldest(playerList);

            var p2 = new HashSet<Player>
            {
                new Player("Sudden", 49),
                new Player("Foppa", 47),
                new Player("Zäta", 40)
            };

            p = GetOldest(p2);

            ILogger logger;
            Console.WriteLine("hur vill du logga? 1=console, 2=file");
            string s = Console.ReadLine();
            if (s == "1")
                logger = new ConsoleLogger();
            else
                logger = new FileLogger();

            
            logger.LogWarning("Test");
            //if(...)
            logger.LogError("Ngt gick fel");
        }
    }
}
