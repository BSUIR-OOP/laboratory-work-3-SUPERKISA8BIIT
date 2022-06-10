using lab3.Interfaces;
using lab3.Struct;

namespace lab3.Transports
{
    public class CargoShip : Transport
    {
        public string Unloading() => $"Unloading cargo...";
        public override string Move() => $"Cargo ship({model}) сrosses the sea";
        public override object FromText(string text)
        {
            var tokens = text.Split(';');
            return new CargoShip()
            {
                model = tokens[0],
                power = int.Parse(tokens[1]),
                capacity = int.Parse(tokens[2])
            };
        }
        public override string ClassName() => "cargoShip";

        public override object Clone()
        {
            return new CargoShip()
            {
                model = model,
                power = power,
                capacity = capacity
            };
        }
    }
}
