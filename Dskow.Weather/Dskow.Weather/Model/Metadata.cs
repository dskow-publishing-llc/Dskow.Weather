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
    public class Metadata
    {
        /// <summary>
        /// Gets or Sets Resultset
        /// </summary>
        [DataMember(Name = "resultset", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resultset")]
        public ResultSet Resultset { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Metadata {\n");
            sb.Append("  Resultset: ").Append(Resultset).Append("\n");
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
