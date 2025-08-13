using RTC_Stock_Management.Services;
using System;
using System.Net.Http;

namespace RTC_Stock_Management.Services
{
    public class ApiService
    {
        public HttpClient Client { get; set; }

        public ApiService()
        {
            var apiSettings = DependencyService.Get<ApiSettings>();
            var (ip, port) = apiSettings.LoadServerSettings();
            Client = new HttpClient
            {
                BaseAddress = new Uri($"http://{ip}:{port}/")
            };
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public void SetBaseUrl(string ip, int port)
        {
            var newBaseUrl = $"http://{ip}:{port}/";
            if (string.IsNullOrWhiteSpace(newBaseUrl))
                throw new ArgumentException("Base URL cannot be empty.", nameof(newBaseUrl));
            Preferences.Set("BaseURL", newBaseUrl);
            Client = new HttpClient
            {
                BaseAddress = new Uri(newBaseUrl)
            };
        }
    }
}