namespace Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.Bus.Configurations
{
    public class MessageConfigurations : IMessageConfigurations
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}