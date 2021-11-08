using System.Collections.Generic;
using DependencyInjection.Library.Models;

namespace DependencyInjection.Library.Repositories
{
    public class ManosRepository
    {
        public IList<Mano> Manos { get; }
        
        public ManosRepository()
        {
            Manos = new List<Mano>();
        }

        public void AdicionarMano(Mano mano)
        {
            Manos.Add(mano);
        }
    }
}