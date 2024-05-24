using ExamProgram.UI.Services.Interfaces;
using RestSharp;

namespace ExamProgram.UI.Services.Implementations;

public class CrudService : ICrudService
{
    private readonly RestClient _client;

    public CrudService()
    {
        _client = new RestClient("https://localhost:7133/api");
    }

    public async Task CreateAsync<T>(string endpoint, T model) where T : class
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(model);
        var response = await _client.PostAsync(request);

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException(response.ErrorMessage);
        }
    }

    public async Task DeleteAsync(string endpoint, int id)
    {
        var request = new RestRequest(endpoint, Method.Delete);
        var response = await _client.DeleteAsync(request);

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException(response.ErrorMessage);
        }
    }

    public async Task<T> GetAllAsync<T>(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync<T>(request);

        if(!response.IsSuccessful)
        {
            throw new HttpRequestException(response.ErrorMessage);
        }

        return response.Data;
    }

    public async Task<T> GetByIdAsync<T>(string endpoint,int id)
    {
        var request = new RestRequest(endpoint, Method.Get);
        var response = await _client.ExecuteAsync<T>(request);

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException(response.ErrorMessage);
        }

        return response.Data;
    }

    public async Task UpdateAsync<T>(string endpoint, T model) where T : class
    {
        var request = new RestRequest(endpoint, Method.Put);
        request.AddJsonBody(model);
        var response = await _client.PutAsync(request);
        if (!response.IsSuccessful)
        {
            throw new HttpRequestException(response.ErrorMessage);
        }
    }
}
