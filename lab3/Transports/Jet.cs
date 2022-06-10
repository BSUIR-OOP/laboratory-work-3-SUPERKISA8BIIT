using lab3.Interfaces;
using lab3.Struct;
using System;

namespace lab3.Transports
{
    public class Jet : Transport
    {

        public override string Move() => $"Jet({model}) flying in sky";
        public string MoveAtSonicSpeed() => "bzzzzz";

        public override object FromText(string text)
        {
            var tokens = text.Split(';');
            return new Jet()
            {
                model = tokens[0],
                power = int.Parse(tokens[1]),
                capacity = int.Parse(tokens[2])
            };
        }

        public override string ClassName() => "jet";

        public override object Clone()
        {
            return new Jet()
            {
                model = model,
                power = power,
                capacity = capacity,
            };
        }
    }
}
