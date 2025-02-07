using KhumalocraftEmporium_ST10069127_CLDV6211POE.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class DurableFunctionService
{
    private readonly HttpClient _httpClient;

    public DurableFunctionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> StartOrderProcessingAsync(Order order)
    {
        var jsonOrder = JsonSerializer.Serialize(order);
        var content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");

        // Call the Durable Function HTTP trigger
        var response = await _httpClient.PostAsync("http://localhost:7071/api/Function1_HttpStart", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
