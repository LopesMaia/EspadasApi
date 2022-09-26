using EspadasApi.Context;
using EspadasApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EspadasApi.Services
{
    public class EspadasService : IEspadaService
    {
        private readonly AppDbContext _context;
        public EspadasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Espada>> GetEspadas()
        {
            try
            {
                return await _context.Espadas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Espada> GetEspada(int id)
        {
            var espada = await _context.Espadas.FindAsync(id);
            return espada;
        }
        public async Task<IEnumerable<Espada>> GetEspadasByName(string nome)
        {
            IEnumerable<Espada> espadas;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                espadas = await _context.Espadas.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                espadas = await GetEspadas();
            }
            return espadas;
        }
        public async Task<IEnumerable<Espada>> GetEspadasByFamilia(string familia)
        {
            IEnumerable<Espada> espadas;
            if (!string.IsNullOrWhiteSpace(familia))
            {
                espadas = await _context.Espadas.Where(n => n.Familia.Contains(familia)).ToListAsync();
            }
            else
            {
                espadas = await GetEspadas();
            }
            return espadas;
        }

        public async Task CreateEspada(Espada espada)
        {
            _context.Espadas.Add(espada);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEspada(Espada espada)
        {
            _context.Entry(espada).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task DeleteEspada(Espada espada)
        {
            _context.Espadas.Remove(espada);
            await _context.SaveChangesAsync();
        }
    }
}