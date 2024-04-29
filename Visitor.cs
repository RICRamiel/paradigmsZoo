using System;

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
}