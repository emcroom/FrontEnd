using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using FrontEnd.Models;
using System.Collections.Generic;


namespace FrontEnd.Data
{

    public class JokesClient 
    {
        private HttpClient _client;
        //private readonly ConfigurationData _config;

        public JokesClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:5003/");
           

        }

        public async Task<Joke> GetRandomJoke()
        {

            try
            {
                var url = new Uri($"api/v1/Jokes/Random", UriKind.Relative);
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Joke>();

            }
            catch (HttpRequestException ex)
            {

                return null;
            }

        }

        public async Task<GroupedJokes> SerachJokes(string searchTerm)
        {

            try
            {
                var url = new Uri($"api/v1/Jokes/Search?searchTerm={searchTerm}", UriKind.Relative);
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<GroupedJokes>();
            }
            catch (HttpRequestException ex)
            {

                return null;
            }
        }

       
    }

}