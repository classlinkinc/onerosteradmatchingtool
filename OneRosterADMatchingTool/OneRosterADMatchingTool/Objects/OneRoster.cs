using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneRosterMatchingTool.Objects
{
    internal class OneRoster
    {
        [JsonProperty("users")]
        public List<OneUser> user { get; set; }
    }

    public class OneUser
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("sourcedId")]
        public string sourcedId { get; set; }

        [JsonProperty("givenName")]
        public string givenName { get; set; }

        [JsonProperty("familyName")]
        public string familyName { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }
    }
}
