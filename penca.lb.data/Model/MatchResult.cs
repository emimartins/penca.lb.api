using System;
namespace penca.lb.data.Model
{
    public class MatchResult: Entity
    {
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Team Winner { get; set; }
        public MatchResult()
        {
        }
    }
}

