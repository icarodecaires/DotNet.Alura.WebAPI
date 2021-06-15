using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.ListaLeitura.HttpClients
{
	public class LivroApiclient
	{
		private readonly HttpClient _httpClient;

		//http://localhost:6000/api/livros/{id}
		//http://localhost:6000/api/listasleitura/paraler
		//http://localhost:6000/api/livros/{id}/capa

		public LivroApiclient(HttpClient httpclient)
		{
			_httpClient = httpclient;
		}

		public async Task<Lista> getListaLeituraAsync(TipoListaLeitura tipo)
		{
			var resposta = await _httpClient.GetAsync($"listasleitura/{tipo}");
			resposta.EnsureSuccessStatusCode();
			return await resposta.Content.ReadAsAsync<Lista>();
		}

		public async Task<byte[]> GetCapaLivroAsync(int id)
		{
			HttpResponseMessage resposta = await _httpClient.GetAsync($"livros/{id}/capa");
			//caso a resposta seja diferente da famila 200 retorna uma excessão
			resposta.EnsureSuccessStatusCode();

			return await resposta.Content.ReadAsByteArrayAsync();
		}

		public async Task<LivroApi> GetLivroAsync(int id)
		{
			HttpResponseMessage resposta = await _httpClient.GetAsync($"livros/{id}");
			//caso a resposta seja diferente da famila 200 retorna uma excessão
			resposta.EnsureSuccessStatusCode();

			return await resposta.Content.ReadAsAsync<LivroApi>();
		}

		public async Task DeleteLivroAsync(int id)
		{
			var resposta = await _httpClient.DeleteAsync($"livros/{id}");
			resposta.EnsureSuccessStatusCode();
		}

	}
}
