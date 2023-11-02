using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Test.Raizen.Application.Services.Google.API
{
    public interface IGoogleApi
    {
        [Get("/")]
        public Task<HttpResponseMessage> GetGoogleAsync();
    }
}
