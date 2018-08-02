using System;
using Newtonsoft.Json;

namespace App1.Model.Cloud
{
    public class CommentsResponse
    {
        [JsonProperty("_meta")]
        public Meta Meta { get; set; }

        [JsonProperty("result")]
        public Comment[] Result { get; set; }
    }
}
