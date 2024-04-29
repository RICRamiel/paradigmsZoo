using System;

class Lion : Animal {
    public Lion() {
        Type = "Lion";
        SaturationLevel = 100;
        SaturationThreshold = 25;
        Status = "Satisfied";
    }

    public override void sound() {
        Console.Write("Rawr\n");
    }
}