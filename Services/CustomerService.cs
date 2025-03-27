using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRMSharp.Models;

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CRMSharp.Models;
using System.Text.Json;
using System.Text;


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

    // Méthode pour importer un fichier JSON
    public async Task<bool> ImportCustomerJson(string jsonContent)
    {
        try
        {
            // Validation et log du JSON
            using (var doc = JsonDocument.Parse(jsonContent))
            {
                Console.WriteLine("JSON validé. Contenu :");
                Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
            }

            // Préparation de la requête
            var content = new StringContent(
                jsonContent,
                Encoding.UTF8,
                "application/json");

            Console.WriteLine("Envoi du contenu :");
            Console.WriteLine(await content.ReadAsStringAsync());

            // Envoi avec timeout
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            var response = await _httpClient.PostAsync("import", content, cts.Token);

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Réponse reçue : {response.StatusCode} - {responseContent}");

            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'import: {ex.ToString()}");
            return false;
        }
    }

}