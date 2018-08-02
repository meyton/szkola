using System;
using Newtonsoft.Json;

namespace App1.Model.Cloud
{
    public class PostsResponse
    {
        [JsonProperty("_meta")]
        public Meta Meta { get; set; }

        [JsonProperty("result")]
        public Post[] Result { get; set; }
    }
}
