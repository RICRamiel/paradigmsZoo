﻿using System;
using System.Collections.Generic;
using System.Threading;


namespace paradigm {
    internal class Program {
        public static void Main(string[] args) {
            Console.Write("Please, enter Zoo`s name\n");
            Zoo zoo = new Zoo(Console.ReadLine());
            Thread updaterThread = new Thread(zoo.updateTick);
            updaterThread.Start();
            Console.Write("Type <Help> to check available commands\n");
            while (zoo.isRunnin()) {
                string command = Console.ReadLine();
                switch (command) {
                    case "Help":
                        Console.Write("\nStop Zoo - to stop running game\n" +
                                      "Check workers - show list of workers and their stats\nCheck animals - show list of animals and their stats\nCheck visitors - show list of visitors and their stats\n" +
                                      "Add worker - add new worker to your zoo\nAdd animal - add new animal to your zoo\nAdd visitor - add new visitor to your zoo\n" +
                                      "Delete worker - fire up worker from your zoo\nDelete animal - transfer animal from your zoo\nDelete visitor - kick visitor from your zoo\n" +
                                      "Edit worker - edit worker's stats\nEdit animal - edit animal's stats\nEdit visitor - edit visitor's stats\n" +
                                      "Attach Animal - attach animal to certain worker\nMake Sound - ");
                        break;
                    case "Check workers":
                        zoo.checkOutWorkers();
                        break;
                    case "Check animals":
                        zoo.checkOutAnimals();
                        break;
                    case "Check visitors":
                        zoo.checkOutVisitors();
                        break;
                    case "Add worker":
                        Console.Write("Please, enter Name, Sex, Job with space separator");
                        Worker.addWorker(zoo);
                        break;
                    case "Add animal":
                        Console.Write("Enter type of animal to add(Lion,Elephant,Otter)\n");
                        string type = Console.ReadLine();
                        Animal.addAnimal(zoo, type);
                        break;
                    case "Add visitor":
                        Console.Write("Please, enter Name and Sex with space separator");
                        Visitor.addVisitor(zoo);
                        break;
                    case "Edit worker":
                        Worker.editWorker(zoo);
                        break;
                    case "Edit animal":
                        Console.Write("Choose animal to edit\n");
                        Animal.editAnimal(zoo);
                        break;
                    case "Edit visitor":
                        Visitor.editVisitor(zoo);
                        break;
                    case "Stop Zoo":
                        Console.Write("Are you sure? Write YES or NO\n");
                        zoo.stopZoo();
                        break;
                    case "Attach Animal":
                        Animal.attachAnimal(zoo);
                        break;
                    case "Delete worker":
                        Worker.deleteWorker(zoo);
                        break;
                    case "Delete animal":
                        Console.Write("Choose animal to delete\n");
                        Animal.deleteAnimal(zoo);
                        break;
                    case "Delete visitor":
                        Visitor.deleteVisitor(zoo);
                        break;
                    case "Make Sound":
                        Console.Write("Choose animal to make Sound\n");
                        zoo.makeSound();
                        break;
                }
            }
        }
    }
}