using System;
using System.Collections.Generic;


abstract class Animal {
    public enum status {
        Hungry,
        Satisfied
    }

    public enum whereIsAnimal {
        Visible,
        NonVisible
    }

    public enum types {
        Lion,
        Elephant,
        Otter
    }

    public status Status { get; set; }
    public types Type { get; set; }
    public whereIsAnimal Visibility { get; set; }
    public int SaturationLevel { get; set; }
    public int SaturationThreshold { get; set; }


    public abstract void sound();

    public void SaturationDown() {
        SaturationLevel -= 1;
    }

    public void statusUpdate() {
        if (SaturationLevel > SaturationThreshold) {
            Status = status.Satisfied;
        }
        else if (SaturationLevel > 0) {
            Status = status.Hungry;
        }
    }

    public status getStatus() {
        return Status;
    }

    public whereIsAnimal getVisibility() {
        return Visibility;
    }

    public void tickMove() {
        Random random = new Random();
        Array val = Enum.GetValues(typeof(whereIsAnimal));
        Visibility = (whereIsAnimal)val.GetValue(random.Next(val.Length));
    }


    public void edit() {
        Console.Write(
            "Please Enter new Saturation(1 - 100), SaturationThreshold(1 - 100) with spaces between\n");
        string[] newThings = Console.ReadLine().Split(' ');
        SaturationLevel = Int32.Parse(newThings[1]);
        SaturationThreshold = Int32.Parse(newThings[2]);
    }

    public static void addAnimal(Zoo zoo, string Type) {
        List<Animal> Animals = zoo.getAnimals();
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

    public static void deleteAnimal(Zoo zoo) {
        List<Animal> Animals = zoo.getAnimals();
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

    public static void editAnimal(Zoo zoo) {
        List<Animal> Animals = zoo.getAnimals();
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

    public void feed() {
        SaturationLevel = 100;
    }

    // public static void attachAnimal(Zoo zoo) {
    //     List<Animal> Animals = zoo.getAnimals();
    //     List<Worker> Workers = zoo.getWorkers();
    //     Console.Write("Choose animal to attach\n");
    //     for (int i = 0; i < Animals.Count; i++) {
    //         Console.Write(
    //             $"________________\n{i}\nStatus: {Animals[i].Status}\nType: {Animals[i].Type}\nLevel: {Animals[i].SaturationLevel}\n");
    //     }
    //
    //     var toAttachAnim = Int32.Parse(Console.ReadLine());
    //
    //     Console.Write("Choose worker to attach animal to\n");
    //     if (Workers.Count == 0) {
    //         Console.Write("There arenot any workers\n");
    //         return;
    //     }
    //
    //     for (int i = 0; i < Workers.Count; i++) {
    //         string temp = "";
    //         foreach (var unit in Workers[i].AttachedAnimal) {
    //             temp += $"{unit}, ";
    //         }
    //
    //         Console.Write(
    //             $"________________\n{i}\nName: {Workers[i].Name}\nSex: {Workers[i].Sex}\nJob:{Workers[i].Job}\nAttachedAnimal:{temp}\n");
    //     }
    //
    //     var toAttachWork = Int32.Parse(Console.ReadLine());
    //     Workers[toAttachWork].AttachedAnimal.Add(toAttachAnim);
    // }
}