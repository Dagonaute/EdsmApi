using System.Numerics;

namespace EdsmApi.Models
{
    public class EdsmSystem
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public int? BodyCount { get; set; }

        public Vector3 Coords { get; set; }

        public EdsmSystemInformation Information { get; set; }

        public EdsmPrimaryStar PrimaryStar { get; set; }

        public bool RequirePermit { get; set; }

        public string PermitName { get; set; }

        public override string ToString()
        {
            var bc = BodyCount.HasValue ? $"{BodyCount} bodies" : "Unknow body count";
            //return $"System [{Name}], Coords=[{Coords}], {Distance} ly from Sol, {bc}";
            return $"System [{Name}], Coords=[{Coords}] ({this.DistanceFromSol()} away from Sol), PrimaryStar=[{PrimaryStar}]";
        }
    }

    //internal class EDSystemCoords
    //{
    //    public decimal X { get; set; }

    //    public decimal Y { get; set; }

    //    public decimal Z { get; set; }

    //    public override string ToString()
    //    {
    //        return $"X={X}, Y={Y}, Z={Z}";
    //    }
    //}

    public class EdsmPrimaryStar
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool? IsScoopable { get; set; }

        public override string ToString()
        {
            return $"Name=[{Name}], Type=[{Type}], Scoopable={IsScoopable}";
        }
    }

    public static class EDSystemHelpers
    {
        public static float DistanceFrom(this EdsmSystem source, EdsmSystem target)
        {
            return Vector3.Distance(source.Coords, target.Coords);
        }

        public static float DistanceFromSol(this EdsmSystem system)
        {
            return system.Coords.Length();
        }
    }
}