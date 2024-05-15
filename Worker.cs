using System;
using System.Collections.Generic;
using System.Linq;

class Worker : Person {
    public string Job { get; set; }
    public List<int> AttachedAviary { get; set; }

    public Worker(string name, string sex, string job) {
        Name = name;
        Sex = sex;
        Job = job;
        AttachedAviary = new List<int>();
    }

    public void edit() {
        Console.Write("Please, enter new Name, Sex, Job with space separator\n");
        string[] newThings = Console.ReadLine().Split(' ');
        Name = newThings[0];
        Sex = newThings[1];
        Job = newThings[2];
    }

    public static void addWorker(Zoo zoo) {
        List<Worker> Workers = zoo.getWorkers();
        string[] temp = Console.ReadLine().Split(' ');
        Workers.Add(new Worker(temp[0], temp[1], temp[2]));
    }

    public static void editWorker(Zoo zoo) {
        List<Worker> Workers = zoo.getWorkers();
        Console.Write("Choose Worker to edit\n");
        for (int i = 0; i < Workers.Count; i++) {
            string temp = "";
            foreach (var unit in Workers[i].AttachedAviary) {
                temp += $"{unit}, ";
            }

            Console.Write(
                $"________________\n{i}\nName: {Workers[i].Name}\nSex: {Workers[i].Sex}\nJob:{Workers[i].Job}\nAttachedAnimal:{temp}\n");
        }

        var toEdit = Int32.Parse(Console.ReadLine());
        if (toEdit > Workers.Count) {
            Console.Write("There is NO worker with this index");
            return;
        }

        Workers[toEdit].edit();
    }

    public static void deleteWorker(Zoo zoo) {
        List<Worker> Workers = zoo.getWorkers();
        Console.Write("Choose Worker to delete\n");
        for (int i = 0; i < Workers.Count; i++) {
            string temp = "";
            foreach (var unit in Workers[i].AttachedAviary) {
                temp += $"{unit}, ";
            }

            Console.Write(
                $"________________\n{i}\nName: {Workers[i].Name}\nSex: {Workers[i].Sex}\nJob:{Workers[i].Job}\nAttachedAnimal:{temp}\n");
        }

        var toDel = Int32.Parse(Console.ReadLine());
        if (toDel > Workers.Count) {
            Console.Write("There is NO Worker with this index");
            return;
        }

        Workers.RemoveAt(toDel);
    }

    public static void attachAviaries(Zoo zoo) {
        List<Worker> Workers = zoo.getWorkers();
        List<Iaviary> Aviaries = zoo.getAviaries();
        foreach (var unit in Workers) {
            unit.AttachedAviary.Clear();
        }
        if (Workers.Count == 0) {
            Console.Write("Firstly, add worker");
            return;
        }
        Random random = new Random();
        for (var unit = 0; unit < Aviaries.Count; unit++) {
            int indexOfWorkerToAttach = random.Next(Workers.Count);
            Workers[indexOfWorkerToAttach].AttachedAviary.Add(unit);
        }
    }

    
}