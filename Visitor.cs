using System;
using System.Collections.Generic;

class Visitor : Person {
    private int Money;
    private int SnackAmount;

    public Visitor(string name, string sex, int money) {
        Name = name;
        Sex = sex;
        Money = money;
    }

    public void edit() {
        Console.Write("Please Enter new Name and Sex with space separator");
        string[] newThings = Console.ReadLine().Split(' ');
        Name = newThings[0];
        Sex = newThings[1];
    }

    public static void addVisitor(Zoo zoo) {
        List<Visitor> Visitors = zoo.getVisitors();
        string[] temp = Console.ReadLine().Split(' ');
        Visitors.Add(new Visitor(temp[0], temp[1], Int32.Parse(temp[2])));
    }

    public static void deleteVisitor(Zoo zoo) {
        List<Visitor> Visitors = zoo.getVisitors();
        Console.Write("Choose Visitor to delete\n");
        for (int i = 0; i < Visitors.Count; i++) {
            Console.Write(
                $"________________\n{i}\nName: {Visitors[i].Name}\nSex: {Visitors[i].Sex}\nMoney: {Visitors[i].Money}");
        }

        var toDel = Int32.Parse(Console.ReadLine());
        if (toDel > Visitors.Count) {
            Console.Write("There is NO visitor with this index");
            return;
        }

        Visitors.RemoveAt(toDel);
    }

    public static void editVisitor(Zoo zoo) {
        List<Visitor> Visitors = zoo.getVisitors();
        Console.Write("Choose Visitor to edit\n");
        for (int i = 0; i < Visitors.Count; i++) {
            Console.Write(
                $"________________\n{i}\nName: {Visitors[i].Name}\nSex: {Visitors[i].Sex}\nMoney: {Visitors[i].Money}\n");
        }

        var toEdit = Int32.Parse(Console.ReadLine());
        if (toEdit > Visitors.Count) {
            Console.Write("There is NO visitor with this index");
            return;
        }

        Visitors[toEdit].edit();
    }

    public void buySnack() {
        Random random = new Random();
        if (random.Next(2) == 1) {
            Money -= 70;
            SnackAmount += 1;
        }
    }

    public void feedAnimal(Zoo zoo) {
        List<aviary> Aviaries = zoo.getAviaries();
        Random random = new Random();
        if (SnackAmount != 0) {
            int AviaryTo = random.Next(Aviaries.Count);
            List<Animal> Animals = Aviaries[AviaryTo].getAnimals();
            foreach (var unit in Animals) {
                if (unit.getVisibility().Equals(Animal.whereIsAnimal.Visible) &&
                    unit.getStatus().Equals(Animal.status.Hungry)) {
                    SnackAmount--;
                    unit.feed();
                    Console.Write($"Visitor feeded animal{unit.GetType()} at Aviary index:{AviaryTo}\n");
                    break;
                }
            }
        }
    }
}