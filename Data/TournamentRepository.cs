using EsportsProphetAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Data
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _context;
        public TournamentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> GetTournaments()
        {
            return await _context.Tournaments
                .AsNoTracking()     // Excludes related objects
                .Include(t => t.Logo)
                .Include(t => t.Teams)
                    .ThenInclude(team => team.Logo)
                .ToListAsync();
        }

        public async Task<Tournament> GetTournament(int id)
        {
            return await _context.Tournaments
                .Include(t => t.Logo)
                .Include(t => t.Teams)
                    .ThenInclude(team => team.Logo)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
