using System;
using System.Collections.Generic;
using System.Threading;

class Zoo {
    public string Name { get; set; }
    private int Timer { get; set; }
    private bool isRunning = true;

    private static List<Worker> Workers = new List<Worker>();
    private static List<Visitor> Visitors = new List<Visitor>();
    private static List<Animal> Animals = new List<Animal>();

    public Zoo(string name) {
        Name = name;
        Timer = 0;
    }

    public void updateTick() {
        while (isRunning) {
            Timer += 1;
            foreach (var unit in Animals) {
                unit.SaturationDown();
                unit.statusUpdate();
            }

            foreach (var unit in Workers) {
                unit.feedAttachedAnimal(Animals);
            }

            Thread.Sleep(5000);
        }
    }

    public bool isRunnin() {
        return isRunning;
    }

    public void stopZoo() {
        string conf = Console.ReadLine();
        switch (conf) {
            case "YES":
                isRunning = false;
                break;
            case "NO":
                isRunning = true;
                break;
        }
    }


    public void checkOutWorkers() {
        foreach (var unit in Workers) {
            string temp = "";
            foreach (var work in unit.AttachedAnimal) {
                temp += $"{work}, ";
            }

            Console.Write(
                $"________________\nName: {unit.Name}\nSex: {unit.Sex}\nJob: {unit.Job}\nAttachedAnimal: {temp}\n");
        }
    }

    public void checkOutVisitors() {
        foreach (var unit in Visitors) {
            Console.Write($"________________\nName: {unit.Name}\nSex: {unit.Sex}\n");
        }
    }


    public void checkOutAnimals() {
        foreach (var unit in Animals) {
            Console.Write(
                $"________________\nStatus: {unit.Status}\nType: {unit.Type}\nLevel: {unit.SaturationLevel}\n");
        }
    }

    public List<Animal> getAnimals() {
        return Animals;
    }

    public List<Worker> getWorkers() {
        return Workers;
    }

    public List<Visitor> getVisitors() {
        return Visitors;
    }
    
    public void makeSound() {
        for (int i = 0; i < Animals.Count; i++) {
            Console.Write(
                $"________________\n{i}\nStatus: {Animals[i].Status}\nType: {Animals[i].Type}\nLevel: {Animals[i].SaturationLevel}\n");
        }

        var toMakeSound = Int32.Parse(Console.ReadLine());
        Animals[toMakeSound].sound();
    }
}