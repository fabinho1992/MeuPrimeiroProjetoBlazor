﻿using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
	public class ArtistaAPI
	{
		private readonly HttpClient _httpClient;

		public ArtistaAPI(IHttpClientFactory factory) //IHttpClientFactory , está sendo usado para performace
		{
			_httpClient = factory.CreateClient("API");
		}

		public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
		{
			return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
		}

		public async Task AddArtistaAsync(ArtistaRequest artistaRequest)
		{
			await _httpClient.PostAsJsonAsync("artistas", artistaRequest);
		}

		public async Task DeleteArtistaAsync(int id)
		{
			await _httpClient.DeleteAsync($"artistas/{id}");
			
		}

        public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
        {
            return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
        }

        public async Task UpdateArtistaAsync(ArtistaRequestEdit artista)
        {
             await _httpClient.PutAsJsonAsync("artistas", artista);
            
        }
    }	
}
