using System;
using Newtonsoft.Json;

namespace App1.Model.Cloud
{
    public class Meta
    {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("code")]
            public long Code { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("total-count")]
            public long TotalCount { get; set; }

            [JsonProperty("page-count")]
            public long PageCount { get; set; }

            [JsonProperty("current-page")]
            public long CurrentPage { get; set; }

            [JsonProperty("per-page")]
            public long PerPage { get; set; }
        }
}
