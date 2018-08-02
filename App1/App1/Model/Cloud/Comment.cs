using System;
using Newtonsoft.Json;

namespace App1.Model.Cloud
{
        public class Comment
        {
            [JsonProperty("id")]
            [JsonIgnore]
            public long Id { get; set; }

            [JsonProperty("post_id")]
            public long PostId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }
        }
}