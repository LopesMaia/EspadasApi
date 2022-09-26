using EspadasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EspadasApi.Services
{
    public interface IEspadaService
    {
        Task<IEnumerable<Espada>> GetEspadas();
        Task<Espada> GetEspada(int id);
        Task<IEnumerable<Espada>> GetEspadasByName(string nome);
        Task<IEnumerable<Espada>> GetEspadasByFamilia(string familia);
        Task CreateEspada(Espada espada);
        Task UpdateEspada(Espada espada);
        Task DeleteEspada(Espada espada);

    }
}
