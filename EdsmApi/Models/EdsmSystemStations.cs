using System.Collections.Generic;

namespace EdsmApi.Models
{
    public class EdsmSystemStations
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public List<EdsmStation> Stations { get; set; }
    }
}
