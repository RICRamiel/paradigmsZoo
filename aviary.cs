using System;
using System.Collections.Generic;

// interface Iaviary{
//     private List<Animal> Animals = new List<Animal>();
//     private int Food { get; set; }
//
//
//     private int AnimalMax = 5;
//     public int getAnimalMax();
//
//
//     public static void addAviary(Zoo zoo);
//     public void checkOutAnimals();
//     public void getInfo();
//     public List<Animal> getAnimals();
//     public int getFood();
//     public void addFood(int amount);
//     public void feedAnimals();
//     public void makeSound();
// }

interface Iaviary {
    int getAnimalMax();
    void addAviary(Zoo zoo);
    void getInfo();
    List<Animal> getAnimals();
    int getFood();
    void addFood(int amount);
    void feedAnimals();
    void makeSound();
}


class aviary : Iaviary {
    private List<Animal> Animals = new List<Animal>();
    private int Food { get; set; }

    private int AnimalMax = 5;

    public aviary() {
        Food = 5;
    }

    public int getAnimalMax() {
        return AnimalMax;
    }

    public void addAviary(Zoo zoo) {
        List<Iaviary> Aviaries = zoo.getAviaries();
        Aviaries.Add(new aviary());
    }

    public void checkOutAnimals() {
        for (var unit = 0; unit < Animals.Count; unit++) {
            Console.Write(
                $"\nId:{unit}\nStatus: {Animals[unit].getStatus()}\nType: {Animals[unit].GetType()}\nLevel: {Animals[unit].getSaturation()}\nIn aviary:{Animals[unit].getVisibility().ToString()}\n");
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
                Food--;
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