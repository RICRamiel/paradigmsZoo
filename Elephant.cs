using System;

class Elephant : Animal {
    public Elephant() {
        Type = "Elephant";
        SaturationLevel = 100;
        SaturationThreshold = 40;
        Status = "Satisfied";
    }

    public override void sound() {
        Console.Write("Whooo\n");
    }
}