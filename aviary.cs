using System;
using System.Collections.Generic;

class aviary {
    private List<Animal> Animals = new List<Animal>();
    private int Food { get; set; }

    private int AnimalMax = 5;

    public aviary() {
        Food = 100;
    }

    public int getAnimalMax() {
        return AnimalMax;
    }

    public static void addAviary(Zoo zoo) {
        List<aviary> Aviaries = zoo.getAviaries();
        Aviaries.Add(new aviary());
    }

    public void checkOutAnimals() {
        for (var unit = 0; unit < Animals.Count; unit++) {
            Console.Write(
                $"\nId:{unit}\nStatus: {Animals[unit].getStatus()}\nType: {Animals[unit].GetType()}\nLevel: {Animals[unit].getSaturation()}\n");
        }
    }

    public void getInfo() {
        Console.Write($"Food:{Food}\n");
        checkOutAnimals();
    }

    public List<Animal> getAnimals() {
        return Animals;
    }

    public int getFood() {
        return Food;
    }

    public void addFood(int amount) {
        Food += amount;
    }

    public void feedAnimals() {
        foreach (var unit in Animals) {
            if (unit.getStatus() == Animal.status.Hungry && Food > 0) {
                unit.feed();
            }
        }
    }

    public void makeSound() {
        for (var unit = 0; unit < Animals.Count; unit++) {
            Console.Write(
                $"\nId:{unit}\nStatus: {Animals[unit].getStatus()}\nType: {Animals[unit].GetType()}\nLevel: {Animals[unit].getSaturation()}\n");
        }

        var toMakeSound = Int32.Parse(Console.ReadLine());
        Animals[toMakeSound].sound();
    }
}