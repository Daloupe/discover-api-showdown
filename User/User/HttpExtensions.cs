using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace User
{
    public static class HttpClientExtensions
    {
        public static HttpClient AddBearerTokenToHeader(this HttpClient cl, string token)
        {
            cl.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
            return cl;
        }
    }
}
