using EdsmApi.Interface;
using EdsmApi.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EdsmApi
{
    /// <summary>
    /// Get systems in a cube - https://www.edsm.net/en/api-v1
    /// </summary>
    public class EdsmQueryCubeSystems : EdsmQueryApiV1, IEdsmQuery<List<EdsmSystem>>
    {
        #region fields
        private static string[] _querySegment = { QueryStrings.cubeSystems };
        #endregion fields

        #region ctor
        /// <summary>
        /// Initialize a new <see cref="EdsmQueryCubeSystems"/> instance.
        /// </summary>
        public EdsmQueryCubeSystems()
            : base(_querySegment)
        {
        }
        #endregion ctor

        #region properties
        /// <summary>
        /// X coordinate of the center of the cube if SystemName is not provided.
        /// </summary>
        [DataMember(Name = EdsmQueryParameterName.x)]
        public float X { get; set; }

        /// <summary>
        /// Y coordinate of the center of the cube if SystemName is not provided.
        /// </summary>
        [DataMember(Name = EdsmQueryParameterName.y)]
        public float Y { get; set; }

        /// <summary>
        /// Z coordinate of the center of the cube if SystemName is not provided.
        /// </summary>
        [DataMember(Name = EdsmQueryParameterName.z)]
        public float Z { get; set; }

        /// <summary>
        /// The size of the cube in ly.
        /// Maximum value is 200.
        /// </summary>
        [DataMember(Name = EdsmQueryParameterName.size)]
        public int Size { get; set; }
        #endregion properties
    }

    public partial class QueryStrings
    {
        public const string cubeSystems = "cube-systems";
    }
}
