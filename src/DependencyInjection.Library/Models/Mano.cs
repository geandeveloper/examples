using System;

namespace DependencyInjection.Library.Models
{
    public class Mano
    {
        public string Name { get; }
        
        public Mano(string name)
        {
            Name = name;
        }

        public override string ToString() => $"Aqui é o mano {Name}";
    }
}