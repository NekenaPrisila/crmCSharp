using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CRMSharp.Models;

public class TicketsService
{
    private readonly HttpClient _httpClient;

    public TicketsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/api/ticket/"); // URL de l'API Spring Boot
    }

    // Méthode pour récupérer tous les tickets
    public async Task<List<TriggerTicket>> GetAllTicketsAsync()
    {
        try
        {
            // Envoie une requête GET à l'endpoint "all-tickets"
            var tickets = await _httpClient.GetFromJsonAsync<List<TriggerTicket>>("all-tickets");
            return tickets ?? new List<TriggerTicket>(); // Retourne une liste vide si la réponse est null
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            Console.WriteLine($"Erreur lors de la récupération des tickets : {ex.Message}");
            return new List<TriggerTicket>(); // Retourne une liste vide en cas d'erreur
        }
    }

    public async Task<bool> DeleteTicketAsync(int id)
    {
        try
        {
            // Envoie une requête DELETE à l'endpoint "delete/{id}"
            var response = await _httpClient.DeleteAsync($"delete/{id}");
            
            // Vérifie si la requête a réussi
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs (ex : log, afficher un message à l'utilisateur)
            Console.WriteLine($"Erreur lors de la suppression du ticket : {ex.Message}");
            return false; // Retourne false en cas d'erreur
        }
    }
    
}
