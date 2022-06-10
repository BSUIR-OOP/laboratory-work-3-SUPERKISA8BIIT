using lab3.Interfaces;
using lab3.Struct;

namespace lab3.Transports
{
    public class Plane: Transport
    {
        public override string Move() => $"Plane({model}) fly in sky";
        public string DoABarrerRoll() => $"Doing barrel roll...";

        public override object FromText(string text)
        {
            var tokens = text.Split(';');
            return new Plane()
            {
                model = tokens[0],
                power = int.Parse(tokens[1]),
                capacity = int.Parse(tokens[2])
            };
        }
        public override string ClassName() => "plane";

        public override object Clone()
        {
            return new Plane()
            {
                model = model,
                power = power,
                capacity = capacity
            };
        }
    }
}
