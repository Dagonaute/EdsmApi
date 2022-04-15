using System.Collections.Generic;

namespace EdsmApi.Models
{
    public class EdsmStation
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public ulong DistanceToArrival { get; set; }

        public string Allegiance { get; set; }

        public string Government { get; set; }

        public string Economy{ get; set; }

        public bool HaveMarket { get; set; }

        public bool HaveShipyard { get; set; }

        public List<EdsmFaction> ControllingFaction { get; set; } = new List<EdsmFaction>();
    }
}
