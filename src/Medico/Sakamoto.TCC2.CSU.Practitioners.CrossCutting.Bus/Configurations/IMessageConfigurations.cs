namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus.Configurations
{
    public interface IMessageConfigurations
    {
        string HostName { get; set; }
        string Password { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
    }
}