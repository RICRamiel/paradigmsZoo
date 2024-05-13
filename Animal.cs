using System;
using System.Collections.Generic;
using System.Linq;


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


    public static void addAnimal(Zoo zoo) {
        List<aviary> Aviaries = zoo.getAviaries();
        Console.Write(
            $"Choose animal type\nId:{(int)types.Lion} {types.Lion.ToString()}\nId:{(int)types.Elephant} {types.Elephant.ToString()}\nId:{(int)types.Otter} {types.Otter.ToString()}");
        var type = Int32.Parse(Console.ReadLine());
        int aviaryTo = 0;
        bool flag = false;
        Console.Write("Choose Aviary to add\n");
        for (var unit = 0; unit < Aviaries.Count; unit++) {
            if ((Aviaries[unit].getAnimals().Count < Aviaries[unit].getAnimalMax() &&
                 Aviaries[unit].getAnimals()[0].Type.Equals(type)) || Aviaries[unit].getAnimals().Count == 0) {
                Console.Write($"\nId:{unit}\n");
                Aviaries[unit].getInfo();
                aviaryTo = Int32.Parse(Console.ReadLine());
                flag = true;
                break;
            }
        }

        if (!flag) {
            Console.Write("There is no suitable aviaries. So creating a new one");
            aviary.addAviary(zoo);
            aviaryTo = Aviaries.Count - 1;
        }

        switch (type) {
            case (int)types.Lion:
                Aviaries[aviaryTo].getAnimals().Add(new Lion());
                break;
            case (int)types.Otter:
                Aviaries[aviaryTo].getAnimals().Add(new Otter());
                break;
            case (int)types.Elephant:
                Aviaries[aviaryTo].getAnimals().Add(new Elephant());
                break;
        }
    }

    public static void deleteAnimal(Zoo zoo) {
        var chosenAv = zoo.chooseAviary();
        aviary Aviary = zoo.getAviaries()[chosenAv];
        List<Animal> Animals = Aviary.getAnimals();
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

    public int getSaturation() {
        return SaturationLevel;
    }

    public static void editAnimal(Zoo zoo) {
        var chosenAv = zoo.chooseAviary();
        aviary Aviary = zoo.getAviaries()[chosenAv];
        List<Animal> Animals = Aviary.getAnimals();
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