using StartWar.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using StarWar.Model;
using Newtonsoft.Json;

namespace StartWar.UI.Service
{
    public class HttpHelperService<T> : HttpClient
    {
        public HttpHelperService()
        {
            BaseAddress = new Uri(Constant.BaseURL);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Result<T>> GetList(string partURL)
        {
            Result<T> result = new Result<T>();
            // HTTP GET
            HttpResponseMessage response = await GetAsync(partURL);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<Result<T>>(await response.Content.ReadAsStringAsync());
            }


            return result;
        }
        public async Task<T> Get(string partURL)
        {

            T t = (T)Activator.CreateInstance(typeof(T));
            // HTTP GET
            HttpResponseMessage response = await GetAsync(partURL);
            if (response.IsSuccessStatusCode)
            {
                t = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            }


            return t;
        }
    }
}
