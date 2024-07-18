using StoreServices.Api.Carts.RemoteInterface;
using StoreServices.Api.Carts.RemoteModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace StoreServices.Api.Carts.RemoteService
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public BookService(IHttpClientFactory httpClientFactory, ILogger<BookService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool resultado, BookRemote, string ErrorMessage)> GetBook(Guid bookId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Books");
                var response = await client.GetAsync($"api/Book/GetById/{bookId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<BookRemote>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
