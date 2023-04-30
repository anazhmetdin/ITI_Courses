using Data.Models;
using System;
using System.Net.Http.Json;

namespace Day2.Services
{
    public class TraineeService
    {
        private readonly HttpClient _httpClient;

        public TraineeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Trainee[]?> GetTraineesAsync()
        {
            return await _httpClient.GetFromJsonAsync<Trainee[]>("https://localhost:7281/api/Trainees");
        }

        public async Task<Trainee?> GetTraineeAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Trainee>($"https://localhost:7281/api/Trainees/{id}");
        }

        public async Task<bool> AddTraineeAsync(Trainee trainee)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7281/api/Trainees", trainee);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateTraineeAsync(int id, Trainee trainee)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7281/api/Trainees/{id}", trainee);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTraineeAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7281/api/Trainees/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
