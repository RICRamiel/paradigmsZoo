using System;
using System.Collections.Generic;
using System.Threading;

class Zoo {
    public string Name { get; set; }
    private int Timer { get; set; }
    private bool isRunning = true;

    private List<Worker> Workers = new List<Worker>();
    private List<Visitor> Visitors = new List<Visitor>();
    private List<Animal> Animals = new List<Animal>();

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

    public void stopZoo() {
        Console.Write("Are you sure? Write YES or NO\n");
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

    public void getTimer() {
        Console.Write(Timer);
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

    public void addWorker() {
        Console.Write("Please, enter Name, Sex, Job with space separator");
        string[] temp = Console.ReadLine().Split(' ');
        Workers.Add(new Worker(temp[0], temp[1], temp[2]));
    }

    public void deleteWorker() {
        Console.Write("Choose Worker to delete\n");
        for (int i = 0; i < Workers.Count; i++) {
            string temp = "";
            foreach (var unit in Workers[i].AttachedAnimal) {
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

    public void editWorker() {
        Console.Write("Choose Worker to edit\n");
        for (int i = 0; i < Workers.Count; i++) {
            string temp = "";
            foreach (var unit in Workers[i].AttachedAnimal) {
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


    public void checkOutVisitors() {
        foreach (var unit in Visitors) {
            Console.Write($"________________\nName: {unit.Name}\nSex: {unit.Sex}\n");
        }
    }

    public void addVisitor() {
        Console.Write("Please, enter Name and Sex with space separator");
        string[] temp = Console.ReadLine().Split(' ');
        Visitors.Add(new Visitor(temp[0], temp[1]));
    }

    public void deleteVisitor() {
        Console.Write("Choose Visitor to delete\n");
        for (int i = 0; i < Visitors.Count; i++) {
            Console.Write(
                $"________________\n{i}\nName: {Visitors[i].Name}\nSex: {Visitors[i].Sex}\n");
        }

        var toDel = Int32.Parse(Console.ReadLine());
        if (toDel > Visitors.Count) {
            Console.Write("There is NO visitor with this index");
            return;
        }

        Visitors.RemoveAt(toDel);
    }

    public void editVisitor() {
        Console.Write("Choose Visitor to edit\n");
        for (int i = 0; i < Visitors.Count; i++) {
            Console.Write(
                $"________________\n{i}\nName: {Visitors[i].Name}\nSex: {Visitors[i].Sex}\n");
        }

        var toEdit = Int32.Parse(Console.ReadLine());
        if (toEdit > Visitors.Count) {
            Console.Write("There is NO visitor with this index");
            return;
        }

        Visitors[toEdit].edit();
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

    public void addAnimal(string Type) {
        switch (Type) {
            case "Lion":
                Animals.Add(new Lion());
                break;
            case "Otter":
                Animals.Add(new Otter());
                break;
            case "Elephant":
                Animals.Add(new Elephant());
                break;
        }
    }

    public void deleteAnimal() {
        Console.Write("Choose animal to delete\n");
        for (int i = 0; i < Animals.Count; i++) {
            Console.Write(
                $"________________\n{i}\nStatus: {Animals[i].Status}\nType: {Animals[i].Type}\nLevel: {Animals[i].SaturationLevel}\n");
        }

        var toDel = Int32.Parse(Console.ReadLine());
        if (toDel > Animals.Count) {
            Console.Write("There is NO animal with this index");
            return;
        }

        Animals.RemoveAt(toDel);
    }

    public void editAnimal() {
        Console.Write("Choose animal to edit\n");
        for (int i = 0; i < Animals.Count; i++) {
            Console.Write(
                $"________________\n{i}\nStatus: {Animals[i].Status}\nType: {Animals[i].Type}\nLevel: {Animals[i].SaturationLevel}\n");
        }

        var toEdit = Int32.Parse(Console.ReadLine());
        if (toEdit > Animals.Count) {
            Console.Write("There is NO animal with this index");
            return;
        }

        Animals[toEdit].edit();
        Animals[toEdit].statusUpdate();
    }

    public void attachAnimal() {
        Console.Write("Choose animal to attach\n");
        for (int i = 0; i < Animals.Count; i++) {
            Console.Write(
                $"________________\n{i}\nStatus: {Animals[i].Status}\nType: {Animals[i].Type}\nLevel: {Animals[i].SaturationLevel}\n");
        }

        var toAttachAnim = Int32.Parse(Console.ReadLine());

        Console.Write("Choose worker to attach animal to");
        for (int i = 0; i < Workers.Count; i++) {
            string temp = "";
            foreach (var unit in Workers[i].AttachedAnimal) {
                temp += $"{unit}, ";
            }

            Console.Write(
                $"________________\n{i}\nName: {Workers[i].Name}\nSex: {Workers[i].Sex}\nJob:{Workers[i].Job}\nAttachedAnimal:{temp}\n");
        }

        var toAttachWork = Int32.Parse(Console.ReadLine());
        Workers[toAttachWork].AttachedAnimal.Add(toAttachAnim);
    }

    public void driver() {
        Console.Write("Type <Help> to check available commands\n");
        while (isRunning) {
            string command = Console.ReadLine();
            switch (command) {
                case "Help":
                    Console.Write("\nStop Zoo - to stop running game\n" +
                                  "Check workers - show list of workers and their stats\nCheck animals - show list of animals and their stats\nCheck visitors - show list of visitors and their stats\n" +
                                  "Add worker - add new worker to your zoo\nAdd animal - add new animal to your zoo\nAdd visitor - add new visitor to your zoo\n" +
                                  "Delete worker - fire up worker from your zoo\nDelete animal - transfer animal from your zoo\nDelete visitor - kick visitor from your zoo\n" +
                                  "Edit worker - edit worker's stats\nEdit animal - edit animal's stats\nEdit visitor - edit visitor's stats\n" +
                                  "Attach Animal - attach animal to certain worker\n");
                    break;
                case "Check workers":
                    checkOutWorkers();
                    break;
                case "Check animals":
                    checkOutAnimals();
                    break;
                case "Check visitors":
                    checkOutVisitors();
                    break;
                case "Add worker":
                    addWorker();
                    break;
                case "Add animal":
                    Console.Write("Enter type of animal to add(Lion,Elephant,Otter)\n");
                    string type = Console.ReadLine();
                    addAnimal(type);
                    break;
                case "Add visitor":
                    addVisitor();
                    break;
                case "Edit worker":
                    editWorker();
                    break;
                case "Edit animal":
                    editAnimal();
                    break;
                case "Edit visitor":
                    editVisitor();
                    break;
                case "Stop Zoo":
                    stopZoo();
                    break;
                case "Attach Animal":
                    attachAnimal();
                    break;
                case "Delete worker":
                    deleteWorker();
                    break;
                case "Delete animal":
                    deleteAnimal();
                    break;
                case "Delete visitor":
                    deleteVisitor();
                    break;
                    
            }
        }
    }
}