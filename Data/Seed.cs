using EsportsProphetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDatabase()
        {
            TeamLogo l1 = new TeamLogo()
            {
                Url = "https://i.ibb.co/XYNjmg5/Team-Secret-logo.png"
            };
            TeamLogo l2 = new TeamLogo()
            {
                Url = "https://i.ibb.co/r4X2Lp6/vp-logo.png"
            };
            TeamLogo l3 = new TeamLogo()
            {
                Url = "https://i.ibb.co/2twr8Gq/liquid-logo.png"
            };
            TeamLogo l4 = new TeamLogo()
            {
                Url = "https://i.ibb.co/0qfPLC8/eg-logo.png"
            };
            TeamLogo l5 = new TeamLogo()
            {
                Url = "https://i.ibb.co/MZFgrt5/LGD-Gaming-logo.png"
            };
            TeamLogo l6 = new TeamLogo()
            {
                Url = "https://i.ibb.co/SfmcjGC/v2-2colorize-gradient.png"
            };

            _context.TeamLogos.Add(l1);
            _context.TeamLogos.Add(l2);
            _context.TeamLogos.Add(l3);
            _context.TeamLogos.Add(l4);
            _context.TeamLogos.Add(l5);

            Team t1 = new Team()
            {
                Logo = l1,
                Name = "Team Secret",
                Tag = "Secret"
            };
            Team t2 = new Team()
            {
                Logo = l2,
                Name = "Virtus Pro",
                Tag = "VP"
            };
            Team t3 = new Team()
            {
                Logo = l3,
                Name = "Team Liquid",
                Tag = "Liquid"
            };
            Team t4 = new Team()
            {
                Logo = l4,
                Name = "Evil Geniuses",
                Tag = "EG"
            };
            Team t5 = new Team()
            {
                Logo = l5,
                Name = "LGD Gaming",
                Tag = "LGD"
            };
            Team t6 = new Team()
            {
                Logo = l6,
                Name = "Obelysk Esports",
                Tag = "OBL"
            };

            _context.Teams.Add(t1);
            _context.Teams.Add(t2);
            _context.Teams.Add(t3);
            _context.Teams.Add(t4);
            _context.Teams.Add(t5);

            TournamentLogo tl1 = new TournamentLogo()
            {
                Url = "https://i.ibb.co/GtVD5KJ/ESL-One-logo.png"
            };
            TournamentLogo tl2 = new TournamentLogo()
            {
                Url = "https://i.ibb.co/1Jm5Qpk/Beyond-The-Summit-logo.png"
            };

            _context.TournamentLogos.Add(tl1);
            _context.TournamentLogos.Add(tl2);

            Tournament tr1 = new Tournament()
            {
                Title = "ESL One",
                Description = "ESL One, the successor to ESL Major Series One, is a tournament series organized by Electronic Sports League.",
                StartDate = DateTime.Now.AddDays(60),
                EndDate = DateTime.Now.AddDays(100),
                Logo = tl1,
                PrizePoolUSD = 100000
            };
            tr1.Teams.Add(t1);
            tr1.Teams.Add(t2);
            tr1.Teams.Add(t3);
            tr1.Teams.Add(t6);
            Tournament tr2 = new Tournament()
            {
                Title = "Beyond the Summit",
                Description = "Beyond the Summit (often abbreviated as BTS) is an esports production company focused on creating unique and authentic events, shows, and content.",
                StartDate = DateTime.Now.AddDays(70),
                EndDate = DateTime.Now.AddDays(110),
                Logo = tl2,
                PrizePoolUSD = 80000
            };
            tr2.Teams.Add(t4);
            tr2.Teams.Add(t5);
            tr2.Teams.Add(t1);
            tr2.Teams.Add(t6);

            _context.Tournaments.Add(tr1);
            _context.Tournaments.Add(tr2);

            _context.SaveChanges();
        }
    }
}
