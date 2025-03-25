using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRMSharp.Models;

public class LoginService
{
    private readonly HttpClient _httpClient;

    public LoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/api/login/"); // URL de l'API Spring Boot
    }

    // Méthode pour créer un TauxAlerte
    public async Task<bool> CheckLogin(string email)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("check-login", email);
            response.EnsureSuccessStatusCode(); // Lève une exception si le statut n'est pas 2xx
            // Désérialiser la réponse en booléen
            var responseContent = await response.Content.ReadFromJsonAsync<bool>();
            Console.WriteLine(responseContent);
            return responseContent;
        }
        catch (HttpRequestException)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            return false;
        }
    }
}
