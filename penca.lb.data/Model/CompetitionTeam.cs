using System;
namespace penca.lb.data.Model
{
    public class CompetitionTeam : Entity
    {
        public Competition Competition { get; set; }
        public long TeamId { get; set; }
        public Team Team { get; set; }
        public string Code { get; set; }

        public CompetitionTeam()
        {
        }
    }
}

