using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRMSharp.Models;
using System.Text;
using System.Net.Http.Headers;

namespace CRMSharp.Services;

public class BudgetAlertApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://existingapp.com/api/budget-alerts";

    public BudgetAlertApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        var byteArray = Encoding.ASCII.GetBytes("admin:password");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    }

    public async Task<BudgetAlert> GetAlertThresholdAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<BudgetAlert>();
        }
        return null;
    }

    public async Task<BudgetAlert> UpdateAlertThresholdAsync(double threshold)
    {
        var response = await _httpClient.PutAsync($"{_baseUrl}?threshold={threshold}", null);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<BudgetAlert>();
        }
        return null;
    }
}