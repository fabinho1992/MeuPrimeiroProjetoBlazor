﻿using ScreenSound.Web.Response;
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
	}	
}
