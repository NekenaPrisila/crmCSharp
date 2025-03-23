using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRMSharp.Models;

public class CustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/api/customer/"); // URL de l'API Spring Boot
    }

    // Méthode pour récupérer tous les Customers
    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        try
        {
            // Envoie une requête GET à l'endpoint "all-Customers"
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>("all-customers");
            return customers ?? new List<Customer>(); // Retourne une liste vide si la réponse est null
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            Console.WriteLine($"Erreur lors de la récupération des Customers : {ex.Message}");
            return new List<Customer>(); // Retourne une liste vide en cas d'erreur
        }
    }
}
