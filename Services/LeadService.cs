using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRMSharp.Models;

public class LeadService
{
    private readonly HttpClient _httpClient;

    public LeadService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/api/lead/"); // URL de l'API Spring Boot
    }

    // Méthode pour récupérer tous les Leads
    public async Task<List<TriggerLead>> GetAllLeadsAsync()
    {
        try
        {
            // Envoie une requête GET à l'endpoint "all-Leads"
            var leads = await _httpClient.GetFromJsonAsync<List<TriggerLead>>("all-leads");
            return leads ?? new List<TriggerLead>(); // Retourne une liste vide si la réponse est null
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            Console.WriteLine($"Erreur lors de la récupération des Leads : {ex.Message}");
            return new List<TriggerLead>(); // Retourne une liste vide en cas d'erreur
        }
    }

    public async Task<bool> DeleteLeadAsync(int id)
    {
        try
        {
            // Envoie une requête DELETE à l'endpoint "delete/{id}" de l'API Lead
            var response = await _httpClient.DeleteAsync($"delete/{id}");
            
            // Vérifie si la requête a réussi
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            Console.WriteLine($"Erreur lors de la suppression du lead : {ex.Message}");
            return false; // Retourne false en cas d'erreur
        }
    }
}
