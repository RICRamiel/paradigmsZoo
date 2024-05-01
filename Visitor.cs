using System;
using System.Collections.Generic;

class Visitor : Person {
    public Visitor(string name, string sex) {
        Name = name;
        Sex = sex;
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
        Visitors.Add(new Visitor(temp[0], temp[1]));
    }
    public static void deleteVisitor(Zoo zoo) {
        List<Visitor> Visitors = zoo.getVisitors();
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
    public static void editVisitor(Zoo zoo) {
        List<Visitor> Visitors = zoo.getVisitors();
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
}
