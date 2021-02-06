using EsportsProphetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Data
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetTournaments();
        Task<Tournament> GetTournament(int id);
    }
}
