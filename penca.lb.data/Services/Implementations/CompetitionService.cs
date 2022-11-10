using System;
using penca.lb.data.Model;
using penca.lb.data.Services.Interfaces;

namespace penca.lb.data.Services.Implementations
{
    public class CompetitionService : ICompetitionService
    {

        public CompetitionService()
        {
        }

        public string GetCompetitionName()
        {
            var c = new Competition();
            return c.Name;
        }
    }
}

