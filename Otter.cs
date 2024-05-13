using System;

class Otter : Animal {
    public Otter() {
        Type = types.Otter;
        SaturationLevel = 100;
        SaturationThreshold = 10;
        Status = status.Satisfied;
    }

    public override void sound() {
        Console.Write("Que Que Que\n");
    }
}