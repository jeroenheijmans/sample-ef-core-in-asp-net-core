using System;

namespace Globalque
{
    public class PingDto
    {
        public DateTime UtcNow => DateTime.UtcNow;
        public string Message => "Server is alive!";
    }
}
