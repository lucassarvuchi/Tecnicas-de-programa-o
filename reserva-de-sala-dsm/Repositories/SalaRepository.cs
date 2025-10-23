﻿using Microsoft.EntityFrameworkCore;
using reserva_de_sala_dsm.Models;

namespace reserva_de_sala_dsm.Repositories
{
    public class SalaRepository : Interfaces.ISalaRepository
    {
        private readonly Data.BancoContext _context;
        public SalaRepository(Data.BancoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Sala sala)
        {
            await _context.Salas.AddAsync(sala);
        }

        public void Delete(Sala sala)
        {
            _context.Salas.Remove(sala);
        }

        public async Task<IEnumerable<Sala>> GetAllAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala> GetByIdAsync(long id)
        {
         return await _context.Salas.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Sala sala)
        {
            _context.Salas.Update(sala);
        }
    }
}
