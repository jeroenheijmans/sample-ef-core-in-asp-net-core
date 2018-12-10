using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace SampleAspNetWithEfCore.Tests
{
    public class DtosTests
    {
        [Trait("Category", "SmokeTest")]
        [Fact]
        public void PingDto_can_be_serialized()
        {
            var original = new PingDto(useUtc: true, messageSuffix: " test");
            var json = JsonConvert.SerializeObject(original);

            Assert.Contains(original.Message, json);
        }
    }
}
