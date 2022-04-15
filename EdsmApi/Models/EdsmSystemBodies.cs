using System.Collections.Generic;

namespace EdsmApi.Models
{
    public class EdsmSystemBodies
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public List<EdsmBody> Bodies { get; set; }
    }
}
