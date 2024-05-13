using System;

class Lion : Animal {
    public Lion() {
        Type = types.Lion;
        SaturationLevel = 100;
        SaturationThreshold = 25;
        Status = status.Satisfied;
    }

    public override void sound() {
        Console.Write("Rawr\n");
    }
}