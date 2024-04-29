using System;
using System.Collections.Generic;

class Worker : Person {
    public string Job { get; set; }
    public List<int> AttachedAnimal { get; set; }

    public Worker(string name, string sex, string job) {
        Name = name;
        Sex = sex;
        Job = job;
        AttachedAnimal = new List<int>();
    }
    public void feedAttachedAnimal(List<Animal> animals) {
        foreach (var index in AttachedAnimal) {
            if (animals[index].Status == "Hungry") {
                animals[index].SaturationLevel = 100;
                animals[index].statusUpdate();
                break;
            }
        }
    }
    public void edit() {
        Console.Write("Please, enter new Name, Sex, Job with space separator\n");
        string[] newThings = Console.ReadLine().Split(' ');
        Name = newThings[0];
        Sex = newThings[1];
        Job = newThings[2];
    }
}