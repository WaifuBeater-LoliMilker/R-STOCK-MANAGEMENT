using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Stock_Management.Services
{
    public class ImportWarehouseService
    {
        public async Task<List<PackingCodes>?> GetPackingCode(string warehouseCode)
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.GetAsync($"import?importwarehousecode={warehouseCode}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<PackingCodes>>(json);
            return info;
        }
        public async Task<List<ImportSerialItem>?> GetSerials(string packingCode)
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.GetAsync($"import/serials?packingcode={packingCode}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<ImportSerialItem>>(json);
            return info;
        }
        public async Task<bool> UpdateSerials(string PackingCode, List<ImportSerialItem> ImportSerialItems,
            int MaterialType, string Location)
        {
            var apiService = DependencyService.Get<ApiService>();
            var payload = new { PackingCode, ImportSerialItems, MaterialType, Location };
            var serialized = JsonConvert.SerializeObject(payload);
            var jsonContent = new StringContent(serialized,
                Encoding.UTF8,
                "application/json");
            var response = await apiService.Client.PostAsync($"import/serials", jsonContent);

            if (!response.IsSuccessStatusCode)
                return false;

            var json = await response.Content.ReadAsStringAsync();
            return true;
        }
    }
    public class PackingCodes
    {
        public int? ImportWarehouseDetailID { get; set; }
        public string Location { get; set; }
        public string PackingCode { get; set; }
        public int MaterialType { get; set; } = 1;
    }
    public class ImportSerialItem
    {
        public string SerialNumber { get; set; }
        public string Location { get; set; }
    }
}