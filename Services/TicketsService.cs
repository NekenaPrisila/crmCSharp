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
            var tickets = await _httpClient.GetFromJsonAsync<List<TriggerTicket>>("all-tickets");
            return tickets ?? new List<TriggerTicket>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur lors de la récupération des tickets : {ex.Message}");
            return new List<TriggerTicket>();
        }
    }

    // Méthode pour supprimer un ticket
    public async Task<bool> DeleteTicketAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"delete/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur lors de la suppression du ticket : {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateTicketExpenseAsync(int id, decimal amount)
    {
        try
        {
            // Crée un objet contenant l'ID et le nouveau montant
            var requestBody = new { Id = id, Expense = amount };

            // Envoie une requête POST à l'endpoint "update-expense"
            var response = await _httpClient.PostAsJsonAsync("update-expense", requestBody);

            // Vérifie si la requête a réussi
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur lors de la mise à jour de l'Expense du ticket : {ex.Message}");
            return false;
        }
    }
}
