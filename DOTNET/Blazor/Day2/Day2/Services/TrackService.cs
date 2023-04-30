using Data.Models;
using System.Net.Http.Json;

namespace Day2.Services
{
    public class TrackService
    {
        private readonly HttpClient _httpClient;

        public TrackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Track[]?> GetTracksAsync()
        {
            return await _httpClient.GetFromJsonAsync<Track[]>("https://localhost:7281/api/Tracks");
        }

        public async Task<Track?> GetTrackAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Track>($"https://localhost:7281/api/Tracks/{id}");
        }

        public async Task<bool> AddTrackAsync(Track track)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7281/api/Tracks", track);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateTrackAsync(int id, Track track)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7281/api/Tracks/{id}", track);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTrackAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7281/api/Tracks/{id}");
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
