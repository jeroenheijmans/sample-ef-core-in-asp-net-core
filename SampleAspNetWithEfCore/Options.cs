using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAspNetWithEfCore
{
    public class SystemOptions
    {
        public bool UseUtc { get; set; } = true;
        public string PingMessageSuffix { get; set; }
    }
}
