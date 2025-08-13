namespace RTC_Stock_Management.Services
{
    internal class ApiSettings
    {
        private const string IpKey = "ServerIP";
        private const string PortKey = "ServerPort";

        public void SaveServerSettings(string ip, int port)
        {
            Preferences.Set(IpKey, ip);
            Preferences.Set(PortKey, port);
        }

        public (string ip, int port) LoadServerSettings()
        {
            string ip = Preferences.Get(IpKey, "10.20.28.235");
            int port = Preferences.Get(PortKey, 500);
            return (ip, port);

        }
    }
}
