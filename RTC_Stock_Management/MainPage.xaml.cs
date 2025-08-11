namespace RTC_Stock_Management
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();
            blazorWebView.Focus();
        }
    }
}
