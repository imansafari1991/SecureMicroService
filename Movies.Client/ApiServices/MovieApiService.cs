using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.Client.Data;
using Movies.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    { private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }
        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");
            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var userInfoResponse = await idpClient.GetUserInfoAsync(
                new UserInfoRequest
                {
                    Address = metaDataResponse.UserInfoEndpoint,
                    Token = accessToken
                }
                );

            if (userInfoResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while getting user info");
                
            }

            var userInfoDictionary = new Dictionary<string, string>();
            foreach (var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }
            return new UserInfoViewModel(userInfoDictionary);

        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {

            //Way1 HttpClientFactory

            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/api/movies/");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);

            return movieList;


            ////Way 2






        //    //1 - Get Token from Identity Server, of course we should provide the IS configuration like address, clientId and clientSecret.
        //    //2 -Send Request to Protected Api
        //    //3 - Deserialize Object to MovieList


        //    //1 . "retrieve" our  api credentials. This must be registered on Identity Server!

        //    var apiClientCredentials = new ClientCredentialsTokenRequest
        //    {
        //        Address = "https://localhost:5005/connect/token",
        //        ClientId = "movieClient",
        //        ClientSecret = "secret",
        //        //This is the scope our Protected Api requires.
        //        Scope = "movieAPI"
        //};
        //    //creates a new HttpClient to talk to our IdentityServer (localhost:5005)
        //    var client = new HttpClient();
        //    //just checks if we can reach the Discovery document. Not 100% needed but ...

        //    var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
        //    if (disco.IsError)
        //    {
        //        return null;//throw  500 Error
        //    }


        //    //2. Authenticates and get an access toke from Identity Server 

        //    var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
        //    if(tokenResponse.IsError)
        //    {
        //        return null;
        //    }

        //    //2- Send Request to Protected API

        //    //Another HttpClient for talking now with our Protected Api

        //    var apiClient = new HttpClient();
        //    //3. Set the Access_token in the request Authorization : Bearer<token>
        //    apiClient.SetBearerToken(tokenResponse.AccessToken);

        //    //4. Send a request to our Protected API
        //    var response = await apiClient.GetAsync("https://localhost:5001/api/movies");
        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //    List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
            
            
        //    return movieList;
        //    //var movieList = new List<Movie>();
        //    //movieList.Add(new Movie
        //    //{
        //    //    Genre = "Drama",
        //    //    Title = "The Shawshank Redemption",
        //    //    Rating = "9.3",
        //    //    ImageUrl = "images/src",
        //    //    ReleaseDate = new DateTime(1994, 5, 5),
        //    //    Owner = "alice"

        //    //}

        //    //);

        //    //return await Task.FromResult<List<Movie>>(movieList);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }


    }
}
