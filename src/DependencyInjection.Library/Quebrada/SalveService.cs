using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Library.Common;
using DependencyInjection.Library.Models;
using DependencyInjection.Library.Repositories;

namespace DependencyInjection.Library.Quebrada
{
    public class SalveService
    {
        private readonly RequestTracker _requestTracker;
        private readonly ManosRepository _manosRepository;

        public SalveService(
            RequestTracker requestTracker,
            ManosRepository manosRepository
        )
        {
            _requestTracker = requestTracker;
            _manosRepository = manosRepository;
        }

        public Task<string> SalveAsync(string name)
        {
            _requestTracker.Track(() => "Procurando alguem para te dar um salve ...");
            var manoDaVez = _manosRepository.Manos.LastOrDefault();

            if (manoDaVez == null)
            {
                _requestTracker.Track(() => "Nenhum mano encontrado...");
                return Task.FromResult("Foi mal parça, não tinha ninguem pra te salvar ...");
            }

            var salveMessage = $"{manoDaVez}, Salve {name}";
            _requestTracker.Track(() => "Salvado com sucesso");
            return Task.FromResult(salveMessage);
        }

        public Task CriarManoAsync(Mano mano)
        {
            _requestTracker.Track(() => "Criando um novo mano :)");
            _manosRepository.AdicionarMano(mano);
            _requestTracker.Track(() => "Mano criado com sucesso");
            return Task.CompletedTask;
        }
    }
}