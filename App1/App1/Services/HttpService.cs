using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using App1.Model.Cloud;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App1.Services
{
    public class HttpService
    {
        public HttpService()
        {
        }

        public async Task<List<Post>> GetPosts()
        {
            List<Post> result = new List<Post>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://gorest.co.in/public-api/posts?_format=json");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var postsResponse = JsonConvert.DeserializeObject<PostsResponse>(jsonResponse);
                if (postsResponse.Meta.Success)
                {
                    result.AddRange(postsResponse.Result);
                }
            }

            return result;
        }

        public async Task<bool> PostComment(Comment comment)
        {
            bool result = false;
            using (var client = new HttpClient())
            {
                MultipartFormDataContent content = new MultipartFormDataContent
                {
                    { new StringContent(comment.Body), "body" },
                    { new StringContent(comment.Name), "name" },
                    { new StringContent(comment.PostId.ToString()), "post_id" },
                    { new StringContent(comment.Email), "email" }
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "LuLSftqQxBAdOleegBBwWnT2VytP_SRpzPXj");
                var response = await client.PostAsync("https://gorest.co.in/public-api/comments", content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var postResponse = JsonConvert.DeserializeObject<PostResponse>(jsonResponse);

                if (postResponse != null)
                    result = postResponse.Meta.Success;
            }

            return result;
        }


        public async Task<bool> PatchComment(Comment comment)
        {
            if (comment.Id < 1)
                return false;
            
            bool result = false;
            using (var client = new HttpClient())
            {
                MultipartFormDataContent content = new MultipartFormDataContent
                {
                    { new StringContent(comment.Body), "body" },
                    { new StringContent(comment.Name), "name" },
                    { new StringContent(comment.PostId.ToString()), "post_id" },
                    { new StringContent(comment.Email), "email" }
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "LuLSftqQxBAdOleegBBwWnT2VytP_SRpzPXj");
                var response = await client.PutAsync($"https://gorest.co.in/public-api/comments/{comment.Id}", content);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var postResponse = JsonConvert.DeserializeObject<PostResponse>(jsonResponse);

                if (postResponse != null)
                    result = postResponse.Meta.Success;
            }

            return result;
        }

        public async Task<List<Comment>> GetComments()
        {
            List<Comment> result = new List<Comment>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://gorest.co.in/public-api/comments?_format=json");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var commentResponse = JsonConvert.DeserializeObject<CommentsResponse>(jsonResponse);
                if (commentResponse.Meta.Success)
                {
                    result.AddRange(commentResponse.Result);
                }
            }

            return result;
        }
    }
}
