using EsportsProphetAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Controllers
{
    [Route("api/[controller]")]
    public class TournamentsController : Controller
    {
        private readonly ITournamentRepository _repo;

        public TournamentsController(ITournamentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            var tournaments = await _repo.GetTournaments();

            return Ok(tournaments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            var tournament = await _repo.GetTournament(id);

            return Ok(tournament);
        }
    }
}
