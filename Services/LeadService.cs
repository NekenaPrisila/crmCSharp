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
            var leads = await _httpClient.GetFromJsonAsync<List<TriggerLead>>("all-leads");
            return leads ?? new List<TriggerLead>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur lors de la récupération des Leads : {ex.Message}");
            return new List<TriggerLead>();
        }
    }

    // Méthode pour supprimer un lead
    public async Task<bool> DeleteLeadAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"delete/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur lors de la suppression du lead : {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateLeadExpenseAsync(int id, decimal amount)
    {
        try
        {
            // Crée un objet contenant l'ID et le nouveau montant
            var requestBody = new { Id = id, Expense = amount };

            Console.WriteLine("tafiditraaa");
            Console.WriteLine($"ID: {id}, Expense: {amount}");

            // Envoie une requête POST à l'endpoint "update-expense"
            var response = await _httpClient.PostAsJsonAsync("update-expense", requestBody);

            // Vérifie si la requête a réussi
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erreur lors de la mise à jour de l'Expense du lead : {ex.Message}");
            return false;
        }
    }
}
