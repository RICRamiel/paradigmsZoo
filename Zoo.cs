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
        this.startUp();
    }

    private void startUp() {
        Random random = new Random();
        for (var count = 0; count < 15; count++) {
            var type = random.Next(3);
            bool flag = false;
            int aviaryTo = 0;
            for (var unit = 0; unit < Aviaries.Count; unit++) {
                if ((Aviaries[unit].getAnimals().Count < Aviaries[unit].getAnimalMax() &&
                     (int)Aviaries[unit].getAnimals()[0].Type == type) || Aviaries[unit].getAnimals().Count == 0) {
                    aviaryTo = unit;
                    flag = true;
                    break;
                }
            }

            if (!flag) {
                aviary.addAviary(this);
                aviaryTo = Aviaries.Count - 1;
            }

            switch (type) {
                case (int)Animal.types.Lion:
                    Aviaries[aviaryTo].getAnimals().Add(new Lion());
                    break;
                case (int)Animal.types.Otter:
                    Aviaries[aviaryTo].getAnimals().Add(new Otter());
                    break;
                case (int)Animal.types.Elephant:
                    Aviaries[aviaryTo].getAnimals().Add(new Elephant());
                    break;
            }
        }

        Console.Write("Please create worker and attach aviaries to him\n");
    }

    public int chooseAviary() {
        Console.Write("Please choose Aviary\n");
        getAviariesInfo();
        var chosen = Int32.Parse(Console.ReadLine());
        return chosen;
    }

    public void getAviariesInfo() {
        for (var unit = 0; unit < Aviaries.Count; unit++) {
            Console.Write($"____________________\nId:{unit}\n");
            Aviaries[unit].getInfo();
        }
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

            foreach (var visit in Visitors) {
                visit.buySnack();
                visit.feedAnimal(this);
            }

            foreach (var unit in Aviaries) {
                unit.feedAnimals();
            }

            fillAviary();
            Thread.Sleep(1000);
        }
    }

    public void fillAviary() {
        foreach (var unit in Workers) {
            foreach (var index in unit.AttachedAviary) {
                if (Aviaries[index].getFood() <= Aviaries[index].getAnimals().Count) {
                    Aviaries[index].addFood(10);
                }
            }
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

    public void animalToSound() {
        var aviarySound = chooseAviary();
        Aviaries[aviarySound].makeSound();
    }

    public List<Worker> getWorkers() {
        return Workers;
    }

    public List<Visitor> getVisitors() {
        return Visitors;
    }

    public List<aviary> getAviaries() {
        return Aviaries;
    }
}