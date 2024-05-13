using System;

class Elephant : Animal {
    public Elephant() {
        Type = types.Elephant;
        SaturationLevel = 100;
        SaturationThreshold = 40;
        Status = status.Satisfied;
    }

    public override void sound() {
        Console.Write("Whooo\n");
    }
}