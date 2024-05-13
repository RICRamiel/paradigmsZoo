using System;
using System.Collections.Generic;

class aviary {
    private List<Animal> Animals = new List<Animal>();;
    private int Food { get; set; }

    private int AnimalMax = 5;

    public void checkOutAnimals() {
        foreach (var unit in Animals) {
            Console.Write(
                $"________________\nStatus: {unit.Status}\nType: {unit.Type}\nLevel: {unit.SaturationLevel}\n");
        }
    }

    public List<Animal> getAnimals() {
        return Animals;
    }

    public int getFood() {
        return Food;
    }

    public void feedAnimals() {
        foreach (var unit in Animals) {
            if (unit.getStatus() == Animal.status.Hungry) {
                unit.feed();
            }
        }
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