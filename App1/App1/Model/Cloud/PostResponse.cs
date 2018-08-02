using System;
using Newtonsoft.Json;

namespace App1.Model.Cloud
{
    public class PostResponse
    {
            [JsonProperty("_meta")]
            public PostMeta Meta { get; set; }

            [JsonProperty("result")]
            public PostField[] Result { get; set; }
    }

    public class PostMeta
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class PostField
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
