using System;

namespace SampleAspNetWithEfCore
{
    public class PingDto
    {
        public DateTime UtcNow => DateTime.UtcNow;
        public string Message => "Server is alive!";
    }
}
