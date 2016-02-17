namespace Definitions.Interfaces.Services
{
    public interface ISettingsService
    {
        string CwAppId { get; }
        string CwCompanyName { get; }
        string CwUrl { get; }
        string ApiPublickKey { get; }
        string ApiPrivateKey { get; }
        string DefaultBoarName { get; }
    }
}