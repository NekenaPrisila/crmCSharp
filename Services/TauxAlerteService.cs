using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRMSharp.Models;

public class TauxAlerteService
{
    private readonly HttpClient _httpClient;

    public TauxAlerteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/api/taux-alerte/"); // URL de l'API Spring Boot
    }

    // Méthode pour créer un TauxAlerte
    public async Task<bool> CreateTauxAlerteAsync(TauxAlerte tauxAlerte)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("create", tauxAlerte);
            response.EnsureSuccessStatusCode(); // Lève une exception si le statut n'est pas 2xx
            return true;
        }
        catch (HttpRequestException)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            return false;
        }
    }
}
