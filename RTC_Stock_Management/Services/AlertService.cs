namespace RTC_Stock_Management.Services
{
    public class AlertService
    {
        public Task ShowAsync(string title, string message, string cancel)
        {
            var page = Application.Current?.Windows[0].Page;
            return page?.DisplayAlert(title, message, cancel) ?? Task.CompletedTask;
        }
    }
}