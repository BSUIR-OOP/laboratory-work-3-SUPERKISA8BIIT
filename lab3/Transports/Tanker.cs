using lab3.Interfaces;
using lab3.Struct;

namespace lab3.Transports
{
    public class Tanker: Transport
    {
        public override string Move() => $"Tanker ship({model}) сrosses the sea";
        public string GetOil() => $"Geting oil from tanker: {capacity}L...";

        public override object FromText(string text)
        {
            var tokens = text.Split(';');
            return new Tanker()
            {
                model = tokens[0],
                power = int.Parse(tokens[1]),
                capacity = int.Parse(tokens[2])
            };
        }
        public override string ClassName() => "tanker";

        public override object Clone()
        {
            return new Tanker()
            {
                model = model,
                power = power,
                capacity = capacity
            };
        }
    }
}
