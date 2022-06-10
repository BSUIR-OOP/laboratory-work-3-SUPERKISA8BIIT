using lab3.Interfaces;
using lab3.Transports;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab3.Struct
{
    public class ListOfTransports : ISerializeble, IEnumerable
    {
        private List<Transport> _container = new List<Transport>();

        private Dictionary<string, ISerializeble> _builder = new Dictionary<string, ISerializeble> {
            {new Jet().ClassName(), new Jet() },
            {new CargoShip().ClassName(), new CargoShip() },
            {new Plane().ClassName(), new Plane() },
            {new Tanker().ClassName(), new Tanker() }
        };
        public Transport this[int index] { get => _container[index]; set => _container[index]=value; }

        public int Count => _container.Count;

        public void Add(Transport item) => _container.Add(item);
        public void RemoveAt(int index) => _container.RemoveAt(index);

        public IEnumerator<Transport> GetEnumerator() => _container.GetEnumerator();
        public object FromText(string text)
        {
            ListOfTransports transports = new();
            var tokens = text.Split('\n');

            foreach (var key in tokens)
            {
                var className = key.Split("@");
                var newTrn = _builder[className[0]].FromText(className[1]);
                transports.Add((Transport)newTrn);
            }
            return transports;
        }


        public string ToText() => $@"{string.Join('\n', _container.Select(x => $@"{x.ClassName()}@{x.ToText()}"))}";

        public string ClassName() => "listOfTransport";

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_container).GetEnumerator();
    }
}
