using System.Collections.Generic;

namespace EdsmApi.Models
{
    /// <summary>
    /// Represents an astronomical body.
    /// </summary>
    public class EdsmBody
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string SubType { get; set; }

        public ulong DistanceToArrival { get; set; }

        #region Type = Star
        public bool IsMainStar { get; set; }

        public bool IsScoopable { get; set; }

        public ulong Age { get; set; }

        public string SpectralClass { get; set; }

        public string Luminosity { get; set; }

        public float AbsoluteMagnitude { get; set; }

        public float SolarMasses { get; set; }

        public float SolarRadius { get; set; }
        #endregion Type = Star

        #region Type = Planet
        public bool IsLandable { get; set; }

        public float Gravity { get; set; }

        public float? SurfacePressure { get; set; }

        public float EarthMasses { get; set; }

        public Dictionary<string, float> Materials { get; set; } = new Dictionary<string, float>();

        public string ReserveLevel { get; set; }

        public float Radius { get; set; }

        public string VolcanismType { get; set; }

        public string AtmosphereType { get; set; }

        public Dictionary<string, float> AtmosphereComposition { get; set; } = new Dictionary<string, float>();

        public Dictionary<string, float> SolidComposition { get; set; } = new Dictionary<string, float>();

        public string TerraformingState { get; set; }
        #endregion Type = Planet

        public ulong SurfaceTemperature { get; set; }

        public float? OrbitalPeriod { get; set; }

        public float? SemiMajorAxis { get; set; }

        public float? OrbitalEccentricity { get; set; }

        public float? OrbitalInclination { get; set; }

        public float? ArgOfPeriapsis { get; set; }

        public float RotationalPeriod { get; set; }

        public bool RotationalPeriodTidallyLocked { get; set; }

        public float? AxialTilt { get; set; }

        public List<EdsmOrbitingObject> Rings { get; set; } = new List<EdsmOrbitingObject>();

        public List<EdsmOrbitingObject> Belts { get; set; } = new List<EdsmOrbitingObject>();
    }
}
