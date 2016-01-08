using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Lisa.Excelsis.Mobile
{
	public class Proxy
	{
		public Proxy(string baseUrl, JsonSerializerSettings jsonSerializerSettings)
		{
			_proxyBaseUrl = new Uri(baseUrl);
			_httpClient = new HttpClient();

			_jsonSerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				NullValueHandling = NullValueHandling.Ignore,
				Converters = new List<JsonConverter>
				{
					new StringEnumConverter
					{
						CamelCaseText = true
					}
				}
			};
		}

		public Proxy(string resourceUrl)
			: this(resourceUrl, null)
		{
		}

		public async Task<IEnumerable<T>> GetAsync<T>(string path, List<Uri> redirectUriList = null)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(String.Format("{0}/{1}", _proxyBaseUrl, path.Trim('/')))
			};

			var result = await _httpClient.SendAsync(request);

			switch (result.StatusCode)
			{
				case HttpStatusCode.OK:
					return await DeserializeList<T>(result);

				case HttpStatusCode.TemporaryRedirect:
				case HttpStatusCode.Redirect:
				case HttpStatusCode.RedirectMethod:
					if (result.Headers.Location != null)
					{
						redirectUriList.Add(result.Headers.Location);
						return await GetAsync<T>(result.Headers.Location, redirectUriList);
					}
					throw new WebApiException("Redirect without Location provided", result.StatusCode);

				case HttpStatusCode.Unauthorized:
				case HttpStatusCode.Forbidden:
					throw new UnauthorizedAccessException();

				case HttpStatusCode.NotFound:
				case HttpStatusCode.Gone:
					return null;
			}

			throw new WebApiException("Unexpected statuscode", result.StatusCode);
		}

		public async Task<T> GetSingleAsync<T>(string path, List<Uri> redirectUriList = null)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(string.Format("{0}/{1}/{2}", _proxyBaseUrl, path.Trim('/'), id))
			};

			var result = await _httpClient.SendAsync(request);

			switch (result.StatusCode)
			{
				case HttpStatusCode.OK:
					return await DeserializeSingle<T>(result);

				case HttpStatusCode.TemporaryRedirect:
				case HttpStatusCode.Redirect:
				case HttpStatusCode.RedirectMethod:
					if (result.Headers.Location != null)
					{
						redirectUriList.Add(result.Headers.Location);
						return await GetSingleAsync<T>(result.Headers.Location, redirectUriList);
					}
					throw new WebApiException("Redirect without Location provided", result.StatusCode);

				case HttpStatusCode.Unauthorized:
				case HttpStatusCode.Forbidden:
					throw new UnauthorizedAccessException();

				case HttpStatusCode.NotFound:
				case HttpStatusCode.Gone:
					return null;
			}

			throw new WebApiException("Unexpected statuscode", result.StatusCode);
		}

		public async Task<T> PostAsync<T>(T model, string path, List<Uri> redirectUriList = null)
		{
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(String.Format("{0}/{1}", _proxyBaseUrl, path.Trim('/'))),
				Content = new StringContent(JsonConvert.SerializeObject(model, _jsonSerializerSettings), Encoding.UTF8, "Application/json")
			};

			var result = await _httpClient.SendAsync(request);

			switch (result.StatusCode)
			{
				case HttpStatusCode.OK:
				case HttpStatusCode.Created:
				case HttpStatusCode.Accepted:
				case HttpStatusCode.BadRequest:
					return await DeserializeSingle<T>(result);

				case HttpStatusCode.NoContent:
					return null;

				case HttpStatusCode.TemporaryRedirect:
				case HttpStatusCode.Redirect:
				case HttpStatusCode.RedirectMethod:
					if (result.Headers.Location != null)
					{
						redirectUriList.Add(result.Headers.Location);
						return await PostAsync<T>(model, result.Headers.Location, redirectUriList);
					}
					throw new WebApiException("Redirect without Location provided", result.StatusCode);

				case HttpStatusCode.Unauthorized:
				case HttpStatusCode.Forbidden:
					throw new UnauthorizedAccessException();
			}

			throw new WebApiException("Unexpected statuscode", result.StatusCode);
		}

		public async Task<T> PatchAsync<T>(int id, T model, string path ,List<Uri> redirectUriList = null)
		{
			var request = new HttpRequestMessage
			{
				Method = new HttpMethod("PATCH"),
				RequestUri = new Uri(String.Format("{0}/{1}/{2}", _proxyBaseUrl, path, id)),
				Content = new StringContent(JsonConvert.SerializeObject(model, _jsonSerializerSettings), Encoding.UTF8, "Application/json")
			};

			var result = await _httpClient.SendAsync(request);

			switch (result.StatusCode)
			{
				case HttpStatusCode.OK:
				case HttpStatusCode.Accepted:
				case HttpStatusCode.NoContent:
				case HttpStatusCode.BadRequest:
					return await DeserializeSingle(result);

				case HttpStatusCode.TemporaryRedirect:
				case HttpStatusCode.Redirect:
				case HttpStatusCode.RedirectMethod:
					if (result.Headers.Location != null)
					{
						redirectUriList.Add(result.Headers.Location);
						return await PostAsync<T>(model, result.Headers.Location, redirectUriList);
					}
					throw new WebApiException("Redirect without Location provided", result.StatusCode);

				case HttpStatusCode.Unauthorized:
				case HttpStatusCode.Forbidden:
					throw new UnauthorizedAccessException();
			}

			throw new WebApiException("Unexpected statuscode", result.StatusCode);
		}

		public async Task DeleteAsync(int id, string path, List<Uri> redirectUriList = null)
		{

			var request = new HttpRequestMessage
			{
				Method = new HttpMethod("DELETE"),
				RequestUri = new Uri(String.Format("{0}/{1}/{2}", _proxyBaseUrl, path.Trim('/'), id))
			};

			var result = await _httpClient.SendAsync(request);

			switch (result.StatusCode)
			{
				case HttpStatusCode.Accepted:
				case HttpStatusCode.NoContent:
					return;

				case HttpStatusCode.TemporaryRedirect:
				case HttpStatusCode.Redirect:
				case HttpStatusCode.RedirectMethod:
					if (result.Headers.Location != null)
					{
						redirectUriList.Add(result.Headers.Location);
						await DeleteAsync(id, result.Headers.Location, redirectUriList);
						return;
					}
					throw new WebApiException("Redirect without Location provided", result.StatusCode);

				case HttpStatusCode.Unauthorized:
				case HttpStatusCode.Forbidden:
					throw new UnauthorizedAccessException();
			}

			throw new WebApiException("Unexpected statuscode", result.StatusCode);
		}

		private void CheckRedirectLoop(Uri uri, ref List<Uri> redirectUriList)
		{
			if (redirectUriList != null && redirectUriList.Contains(uri))
			{
				throw new WebApiException("Endless redirect loop", HttpStatusCode.Redirect);
			}

			redirectUriList = new List<Uri>();
		}

		private async Task<T> DeserializeSingle<T>(HttpResponseMessage response)
		{
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
		}

		private async Task<IEnumerable<T>> DeserializeList<T>(HttpResponseMessage response)
		{
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<IEnumerable<T>>(json, _jsonSerializerSettings);
		}

		private readonly HttpClient _httpClient;
		private readonly Uri _proxyBaseUrl;
		private readonly JsonSerializerSettings _jsonSerializerSettings;
	}

	public class WebApiException : Exception
	{
		public WebApiException(string message, HttpStatusCode statusCode)
			: base(message)
		{
			StatusCode = statusCode;
		}

		public WebApiException(string message, HttpStatusCode statusCode, Exception innerException)
			: base(message, innerException)
		{
			StatusCode = statusCode;
		}

		public HttpStatusCode StatusCode { get; set; }
	}
}