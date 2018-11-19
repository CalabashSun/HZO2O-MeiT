using System;
using System.Net.Http;

namespace MeituanApi.Core.HttpClient
{
    public  class HttpClientHelper
    {
        public System.Net.Http.HttpClient Client { get; private set; }

        public HttpClientHelper(System.Net.Http.HttpClient httpClient)
        {
            httpClient.BaseAddress=new Uri("https://waimaiopen.meituan.com/api/v1/");
            Client = httpClient;
        }


    }
}
