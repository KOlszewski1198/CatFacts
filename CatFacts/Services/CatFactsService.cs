using Restaurant2API.Exeptions;
using CatFacts.Models;

namespace CatFacts.Controllers
{
    public interface ICatFactsService
    {
        Task<CatFactsModel> Get();
    }

    public class CatFactsService : ICatFactsService
    {
        private readonly HttpClient _httpClient;

        public CatFactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFactsModel> Get()
        {
            var URL = "fact";
            var response = await _httpClient.GetAsync(URL);
            var fact = await response.Content.ReadFromJsonAsync<CatFactsModel>();

            if (fact == null || fact.Length == 0)
                throw new NotFoundException("No result");

            return fact;
        }
    }
}