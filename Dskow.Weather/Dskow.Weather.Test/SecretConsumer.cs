using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Dskow.Weather.Test
{
    public class SecretConsumer
    {
        private readonly WeatherConfig _secrets;
        public SecretConsumer(IOptions<WeatherConfig> secrets)
        {
            _secrets = secrets.Value;
        }
    }
}
