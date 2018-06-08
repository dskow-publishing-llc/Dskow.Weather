using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Dskow.Weather.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Station
    {
        /// <summary>
        /// Gets or Sets Elevation
        /// </summary>
        [DataMember(Name = "elevation", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "elevation")]
        public float? Elevation { get; set; }

        /// <summary>
        /// Gets or Sets Mindate
        /// </summary>
        [DataMember(Name = "mindate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "mindate")]
        public DateTime? Mindate { get; set; }

        /// <summary>
        /// Gets or Sets Maxdate
        /// </summary>
        [DataMember(Name = "maxdate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxdate")]
        public DateTime? Maxdate { get; set; }

        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "latitude")]
        public float? Latitude { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Datacoverage
        /// </summary>
        [DataMember(Name = "datacoverage", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "datacoverage")]
        public float? Datacoverage { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ElevationUnit
        /// </summary>
        [DataMember(Name = "elevationUnit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "elevationUnit")]
        public string ElevationUnit { get; set; }

        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "longitude")]
        public float? Longitude { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Station {\n");
            sb.Append("  Elevation: ").Append(Elevation).Append("\n");
            sb.Append("  Mindate: ").Append(Mindate).Append("\n");
            sb.Append("  Maxdate: ").Append(Maxdate).Append("\n");
            sb.Append("  Latitude: ").Append(Latitude).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Datacoverage: ").Append(Datacoverage).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ElevationUnit: ").Append(ElevationUnit).Append("\n");
            sb.Append("  Longitude: ").Append(Longitude).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
