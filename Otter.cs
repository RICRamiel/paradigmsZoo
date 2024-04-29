using System;

class Otter : Animal {
    public Otter() {
        Type = "Otter";
        SaturationLevel = 100;
        SaturationThreshold = 10;
        Status = "Satisfied";
    }

    public override void sound() {
        Console.Write("Que Que Que\n");
    }
}