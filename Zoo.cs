using System;
using System.Collections.Generic;
using System.Threading;


class Zoo {
    public string Name { get; set; }
    private int Timer { get; set; }
    private bool isRunning = true;

    private static List<Worker> Workers = new List<Worker>();
    private static List<Visitor> Visitors = new List<Visitor>();
    private static List<aviary> Aviaries = new List<aviary>();

    public Zoo(string name) {
        Name = name;
        Timer = 0;
    }

    private void startUp() {
    }

    public void updateTick() {
        while (isRunning) {
            Timer += 1;
            foreach (var aviar in Aviaries) {
                foreach (var ani in aviar.getAnimals()) {
                    ani.SaturationDown();
                    ani.tickMove();
                    ani.statusUpdate();
                }
            }

            foreach (var unit in Aviaries) {
                unit.feedAnimals();
            }

            Thread.Sleep(5000);
        }
    }

    public bool isRunnin() {
        return isRunning;
    }


    public void pauseZoo(Thread thread) {
        thread.Suspend();
    }

    public void resumeZoo(Thread thread) {
        thread.Resume();
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
            foreach (var work in unit.AttachedAviary) {
                temp += $"{work}, ";
            }

            Console.Write(
                $"________________\nName: {unit.Name}\nSex: {unit.Sex}\nJob: {unit.Job}\nAttachedAviary: {temp}\n");
        }
    }

    public void checkOutVisitors() {
        foreach (var unit in Visitors) {
            Console.Write($"________________\nName: {unit.Name}\nSex: {unit.Sex}\n");
        }
    }


 

    public List<Worker> getWorkers() {
        return Workers;
    }

    public List<Visitor> getVisitors() {
        return Visitors;
    }

    
}