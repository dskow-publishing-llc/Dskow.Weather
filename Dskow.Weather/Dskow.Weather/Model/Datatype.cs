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
    public class Datatype
    {
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
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Datatype {\n");
            sb.Append("  Mindate: ").Append(Mindate).Append("\n");
            sb.Append("  Maxdate: ").Append(Maxdate).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Datacoverage: ").Append(Datacoverage).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
