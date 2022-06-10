using lab3.Interfaces;
using lab3.Struct;
using System;

namespace lab3.Transports
{
    public abstract class Transport : ISerializeble, ICloneable
    {
        public string model { get; set; }
        public int power { get; set; }
        public int capacity { get; set; }

        public abstract string ClassName();

        public abstract object Clone();

        public abstract object FromText(string text);

        public abstract string Move();

        public virtual string ToText()
        {
            return $@"{model};{power};{capacity}";
        }
    }
}
