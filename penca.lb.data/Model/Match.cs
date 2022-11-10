using System;
namespace penca.lb.data.Model
{
    public class Match : Entity
    {
        public Team Home { get; set; }
        public Team Away { get; set; }
        public string Description { get; set; }
        public MatchResult Result { get; set; }
        public Round Round { get; set; }

        public Match()
        {
            
        }
    }
}

