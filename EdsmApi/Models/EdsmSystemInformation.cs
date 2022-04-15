namespace EdsmApi.Models
{
    public class EdsmSystemInformation
    {
        public string Allegiance { get; set; }

        public string Government { get; set; }

        public string Faction { get; set; }

        public string FactionState { get; set; }

        public ulong Population { get; set; }

        public string Security { get; set; }

        public string Economy { get; set; }

        public string SecondEconomy { get; set; }

        public string Reserve { get; set; }
    }
}