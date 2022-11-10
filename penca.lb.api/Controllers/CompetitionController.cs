using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using penca.lb.data.Model;
using penca.lb.data.Repository.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace penca.lb.api.Controllers
{
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionRepository _competitionRepository;
        public CompetitionController(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        [HttpPost("competition")]
        public string AddCompetition(Competition competition)
        {
            _competitionRepository.Create(competition);
            _competitionRepository.Save();
            return "OK";
        }


        [HttpGet("competition")]
        public IEnumerable<Competition> GetCompetitions()
        {
            var competitions = _competitionRepository.All();
            return competitions;
        }

    }
}

