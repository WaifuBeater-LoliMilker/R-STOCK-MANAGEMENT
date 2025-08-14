using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Stock_Management.Services
{
    public class ExportWarehouseService
    {
        public async Task<List<ExportWarehouseDetail>?> GetMaterialCode(string warehouseCode)
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.GetAsync($"export?exportwarehousecode={warehouseCode}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<ExportWarehouseDetail>>(json);
            return info;
        }
        public async Task<List<ExportSerialItem>?> GetSerials(string materialCode)
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.GetAsync($"export/serials?materialcode={materialCode}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<List<ExportSerialItem>>(json);
            return info;
        }
        public async Task<bool> UpdateSmallType(string materialCode, decimal quantityReal)
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.PostAsync(
                $"export/warehouse-details-small?material-code={materialCode}&quantity-real={quantityReal}", null);

            if (!response.IsSuccessStatusCode)
                return false;

            var json = await response.Content.ReadAsStringAsync();
            return true;
        }
        public async Task<decimal> UpdateLargeType(string materialcode, string serial )
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.PostAsync(
                $"export/warehouse-details-large?material-code={materialcode}&serial={serial}", null);

            if (!response.IsSuccessStatusCode)
                return 0;

            var json = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<decimal>(json);
            return info;
        }
    }
    public class ExportWarehouseDetail
    {
        public string MaterialCode { get; set; }
        public int? Status { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QuantityReal { get; set; }
        public int? MaterialType { get; set; }
    }
    public class ExportSerialItem
    {
        public string PackingCode { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
    }
}
