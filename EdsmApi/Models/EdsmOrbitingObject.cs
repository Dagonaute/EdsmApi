namespace EdsmApi.Models
{
    public class EdsmOrbitingObject
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public ulong Mass { get; set; }

        public ulong InnerRadius { get; set; }

        public ulong OuterRadius { get; set; }
    }
}
