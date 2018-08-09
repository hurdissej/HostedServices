using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class QuoteProvider
{
    private const string quoteSource = "http://quotes.stormconsultancy.co.uk/random.json";
    public Quote RandomQuote { get; private set; } = new Quote();


    private readonly HttpClient _httpClient;
    public QuoteProvider()
    {
        _httpClient = new HttpClient();
    }

    public async Task UpdateString(CancellationToken token)
    {
        try
        {
            var response = await _httpClient.GetAsync(quoteSource, token);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                RandomQuote = Newtonsoft.Json.JsonConvert.DeserializeObject<Quote>(content);
            }
        }
        catch (Exception e)
        {
            //Swallow up the exception and don't let it bring down the whole process
            Console.WriteLine(e.Message);
        }
    }
}
