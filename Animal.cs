using System;

abstract class Animal {
    public string Status { get; set; }
    public string Type { get; set; }
    public int SaturationLevel { get; set; }
    public int SaturationThreshold { get; set; }

    public abstract void sound();

    public void SaturationDown() {
        SaturationLevel -= 1;
    }

    public void statusUpdate() {
        if (SaturationLevel > SaturationThreshold) {
            Status = "Satisfied";
        }
        else if (SaturationLevel > 0) {
            Status = "Hungry";
        }
    }

    public void edit() {
        Console.Write(
            "Please Enter new Status (Satisfied,Hungry), Saturation(1 - 100), SaturationThreshold(1 - 100) with spaces between\n");
        string[] newThings = Console.ReadLine().Split(' ');
        Status = newThings[0];
        SaturationLevel = Int32.Parse(newThings[1]);
        SaturationThreshold = Int32.Parse(newThings[2]);
    }
}