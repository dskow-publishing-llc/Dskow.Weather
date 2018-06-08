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
    public class Data
    {
        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or Sets Datatype
        /// </summary>
        [DataMember(Name = "datatype", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "datatype")]
        public string Datatype { get; set; }

        /// <summary>
        /// Gets or Sets Station
        /// </summary>
        [DataMember(Name = "station", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "station")]
        public string Station { get; set; }

        /// <summary>
        /// Gets or Sets Attributes
        /// </summary>
        [DataMember(Name = "attributes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "attributes")]
        public string Attributes { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Data {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Datatype: ").Append(Datatype).Append("\n");
            sb.Append("  Station: ").Append(Station).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
