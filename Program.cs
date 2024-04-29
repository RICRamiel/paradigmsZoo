using System;
using System.Threading;


namespace paradigm {
    internal class Program {
        public static void Main(string[] args) {
            Console.Write("Please, enter Zoo`s name\n");
            Zoo zoo = new Zoo(Console.ReadLine());
            Thread updaterThread = new Thread(zoo.updateTick);
            updaterThread.Start();
            zoo.driver();
        }
    }
}